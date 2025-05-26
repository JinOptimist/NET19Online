using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreData.Models;
using StoreData.Repostiroties;
using WebStoryFroEveryting.Models.Jerseys;
using WebStoryFroEveryting.Services;
using WebStoryFroEveryting.Controllers.CustomAutorizeAttributes;
using Enums.User;
using WebStoryFroEveryting.Controllers.ApiControllers;
using System.Text;
using System.Reflection;
using WebStoryFroEveryting.Services.JerseyServices;
using OfficeOpenXml;

namespace WebStoryFroEveryting.Controllers
{
    public class JerseysController : Controller
    {
        private JerseyGenerator _jerseyGenerator;
        private JerseyRepository _jerseyRepository;
        private JerseyCommentRepository _jerseyCommentRepository;
        private AuthService _authService;
        private JerseyApiReflectionWatcher _jerseyApiReflectionWatcher;
        private IHttpContextAccessor _httpContextAccessor;
        private IConfiguration _configuration;
        private JerseyCartViewModel _cart;
        public JerseysController
            (
                JerseyGenerator jerseyGenerator,
                JerseyRepository jerseyRepository,
                JerseyCommentRepository jerseyCommentRepository,
                AuthService authService,
                JerseyApiReflectionWatcher jerseyApiReflectionWatcher,
                IHttpContextAccessor httpContextAccessor,
                IConfiguration configuration
            )
        {
            _jerseyGenerator = jerseyGenerator;
            _jerseyRepository = jerseyRepository;
            _jerseyCommentRepository = jerseyCommentRepository;
            _authService = authService;
            _jerseyApiReflectionWatcher = jerseyApiReflectionWatcher;
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
            _cart = _httpContextAccessor.HttpContext.Session.GetObjectFromJson<JerseyCartViewModel>(_configuration["Constants:SessionCartkey"]);
        }
        public ActionResult Index(string? tag)
        {
            var jerseys = _jerseyRepository.GetAllWithTags(tag);
            if (!jerseys.Any())
            {
                _jerseyGenerator.GenerateData()
                    .Select(jersey =>
                        new JerseyData
                        {
                            AthleteName = jersey.AthleteName,
                            Club = jersey.Club,
                            Img = jersey.Img,
                            SecondImg = jersey.SecondImg,
                            Number = jersey.Number,
                            InStock = jersey.InStock,
                            Price = jersey.Price
                        })
                    .ToList()
                    .ForEach(_jerseyRepository.Add);
                jerseys = _jerseyRepository.GetAll();
            }
            var viewModel = new JerseyIndexViewModel();
            viewModel.Jerseys = jerseys.Select(Map).ToList();
            viewModel.Tags = jerseys
                .SelectMany(x => x.Tags)
                .Select(x => x.Tag)
                .Distinct()
                .ToList();
            viewModel.CurrentTag = tag;
            viewModel.IsAdmin = _authService.IsAdmin();
            viewModel.Cart = _cart;
            return View(viewModel);
        }
        public ActionResult Detail(int jerseyId)
        {
            var jersey = _jerseyRepository.GetWithCommentsAndTags(jerseyId);

            if (jersey is null)
            {
                Response.StatusCode = 404;
                return View("JerseysError");
            }
            var viewModel = new JerseyWithCommentsViewModel
            {
                Id = jersey.Id,
                AthleteName = jersey.AthleteName,
                Club = jersey.Club,
                Img = jersey.Img,
                Number = jersey.Number,
                Price = jersey.Price
            };
            viewModel.IsTagCreatingEnable = _authService.IsAuthenticated() && _authService.GetUserId() == 1;
            viewModel.IsAuthenticated = _authService.IsAuthenticated();
            viewModel.Tags = jersey.Tags
                .Select(x => x.Tag)
                .ToList();
            viewModel.Comments = jersey.Comments
                .Select(x => new JerseyCommentViewModel
                {
                    Id = x.Id,
                    Created = x.Created,
                    Comment = x.Comment,
                    UserName = x.Author is null ? "Аноним" : x.Author.UserName

                }).ToList();
            viewModel.Cart = _cart;
            return View(viewModel);
        }

        [IsAdmin]
        public ActionResult Data()
        {
            return View();
        }

        public IActionResult GetExcelData()
        {
            ExcelPackage.License.SetNonCommercialOrganization("Only for student project");
            var jerseys = _jerseyRepository.GetAll();
            using (ExcelPackage package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Sheet1");
                worksheet.Cells["A1"].Value = "Id";
                worksheet.Cells["B1"].Value = "Club";
                worksheet.Cells["C1"].Value = "Number";
                worksheet.Cells["D1"].Value = "AthleteName";
                worksheet.Cells["E1"].Value = "Img";
                worksheet.Cells["F1"].Value = "SecondImg";
                worksheet.Cells["G1"].Value = "InStock";
                worksheet.Cells["H1"].Value = "Price";

                int row = 2;
                foreach (var jersey in jerseys)
                {
                    worksheet.Cells[row, 1].Value = jersey.Id;
                    worksheet.Cells[row, 2].Value = jersey.Club;
                    worksheet.Cells[row, 3].Value = jersey.Number;
                    worksheet.Cells[row, 4].Value = jersey.AthleteName;
                    worksheet.Cells[row, 5].Value = jersey.Img;
                    worksheet.Cells[row, 6].Value = jersey.SecondImg;
                    worksheet.Cells[row, 7].Value = jersey.InStock;
                    worksheet.Cells[row, 8].Value = jersey.Price;
                    row++;
                }
                var stream = new MemoryStream(package.GetAsByteArray());
                return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Export.xlsx");
            }
        }

        [HttpPost]
        public IActionResult UploadExcelData(IFormFile file)
        {
            bool status = false;
            if (file == null || file.Length == 0)
            {
                return BadRequest("Файл не найден.");
            }
            using (var stream = new MemoryStream())
            {
                file.CopyTo(stream);
                ExcelPackage.License.SetNonCommercialOrganization("Only for student project");
                using (var package = new ExcelPackage(stream))
                {
                    var worksheet = package.Workbook.Worksheets[0]; // Берем первый лист
                    int rowCount = worksheet.Dimension.Rows;

                    var listOfJerseys = new List<JerseyData>();

                    for (int row = 2; row <= rowCount; row++) // Начинаем со 2-й строки (пропускаем заголовки)
                    {
                        var newJersey = new JerseyData();
                        newJersey.Id = CheckEmptyExcelCell(worksheet.Cells[row, 1]) ? 0 : int.Parse(worksheet.Cells[row, 1].Value.ToString());
                        newJersey.Club = CheckEmptyExcelCell(worksheet.Cells[row, 2]) ? " " : worksheet.Cells[row, 2].Value.ToString();
                        newJersey.Number = CheckEmptyExcelCell(worksheet.Cells[row, 3]) ? 0 : int.Parse(worksheet.Cells[row, 3].Value.ToString());
                        newJersey.AthleteName = CheckEmptyExcelCell(worksheet.Cells[row, 4]) ? " " : worksheet.Cells[row, 4].Value.ToString();
                        newJersey.Img = CheckEmptyExcelCell(worksheet.Cells[row, 5]) ? " " : worksheet.Cells[row, 5].Value.ToString();
                        newJersey.SecondImg = CheckEmptyExcelCell(worksheet.Cells[row, 6]) ? " " : worksheet.Cells[row, 6].Value.ToString();
                        newJersey.InStock = CheckEmptyExcelCell(worksheet.Cells[row, 7]) ? 0 : int.Parse(worksheet.Cells[row, 7].Value.ToString());
                        newJersey.Price = CheckEmptyExcelCell(worksheet.Cells[row, 8]) ? 0 : decimal.Parse(worksheet.Cells[row, 8].Value.ToString());

                        listOfJerseys.Add(newJersey);

                    }

                    status = _jerseyRepository.UpdateJerseysFromList(listOfJerseys);
                }
            }
            if (status)
            {
                return Ok("Данные успешно загружены и обновлены!");
            }
            return BadRequest("Ошибка импортирования!");
        }

        [HttpGet]
        [IsAdmin]
        public IActionResult AdminChat()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult AddComment(int jerseyId, string commentText)
        {
            var userId = _authService.GetUserId();
            _jerseyCommentRepository.AddComment(jerseyId, commentText, userId);
            return RedirectToAction(nameof(Detail), new { jerseyId });
        }
        [HttpPost]
        [HasPermission(Permisson.CanCreateJerseyTag)]
        public IActionResult AddTag(int jerseyId, string tag)
        {
            _jerseyRepository.AddTag(jerseyId, tag);

            return RedirectToAction(nameof(Detail), new { jerseyId });
        }
        [HttpGet]
        [HasPermission(Permisson.CanRemoveJersey)]
        public IActionResult Remove(int jerseyId)
        {
            _jerseyRepository.Remove(jerseyId);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        [HasPermission(Permisson.CanCreateJersey)]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [HasPermission(Permisson.CanCreateJersey)]
        public IActionResult Create(CreateJerseyViewModel createJerseyViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(createJerseyViewModel);
            }
            _jerseyRepository.Add(
                    new JerseyData
                    {
                        AthleteName = createJerseyViewModel.AthleteName,
                        Club = createJerseyViewModel.Club,
                        Img = createJerseyViewModel.Img,
                        SecondImg = createJerseyViewModel.SecondImg,
                        Number = createJerseyViewModel.Number,
                        InStock = createJerseyViewModel.InStock,
                        Price = createJerseyViewModel.Price
                    });
            return RedirectToAction(nameof(Index));
        }
        [IsAdmin]
        public IActionResult DeleteCommentDuplicates()
        {
            _jerseyCommentRepository.DeleteCommentDuplicates();
            return RedirectToAction(nameof(Index));
        }
        private JerseyViewModel Map(JerseyData jerseyData)
        {
            return new JerseyViewModel
            {
                Id = jerseyData.Id,
                Number = jerseyData.Number,
                AthleteName = jerseyData.AthleteName,
                Img = jerseyData.Img,
                Club = jerseyData.Club,
                InStock = jerseyData.InStock,
                Price = jerseyData.Price,
                SecondImg = jerseyData.SecondImg
            };
        }

        public IActionResult Logos()
        {
            return View();
        }
        public IActionResult ViewApiController()
        {
            return View("ViewApiController", _jerseyApiReflectionWatcher.GetAllInfo());
        }

        public bool CheckEmptyExcelCell(ExcelRange cell)
        {
            return cell.Value == null || string.IsNullOrEmpty(cell.Value.ToString());
        }
    }

}
