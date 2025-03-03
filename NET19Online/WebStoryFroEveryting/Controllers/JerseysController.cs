using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreData.Models;
using StoreData.Repostiroties;
using WebStoryFroEveryting.Models.Jerseys;
using WebStoryFroEveryting.Services;
using WebStoryFroEveryting.Controllers.CustomAutorizeAttributes;
using Enums.User;

namespace WebStoryFroEveryting.Controllers
{
    public class JerseysController : Controller
    {
        private JerseyGenerator _jerseyGenerator;
        private JerseyRepository _jerseyRepository;
        private JerseyCommentRepository _jerseyCommentRepository;
        private AuthService _authService;

        public JerseysController(JerseyGenerator jerseyGenerator, JerseyRepository jerseyRepository, JerseyCommentRepository jerseyCommentRepository, AuthService authService)
        {
            _jerseyGenerator = jerseyGenerator;
            _jerseyRepository = jerseyRepository;
            _jerseyCommentRepository = jerseyCommentRepository;
            _authService = authService;
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
                    UserName = x.Author is null ? "Аноним": x.Author.UserName

                }).ToList();

            return View(viewModel);
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
                        Number = createJerseyViewModel.Number,
                        InStock = createJerseyViewModel.InStock,
                        Price = createJerseyViewModel.Price
                    });
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
                Price = jerseyData.Price
            };
        }
    }
}
