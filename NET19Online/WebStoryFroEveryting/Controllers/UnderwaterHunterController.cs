﻿using Enums.User;
using Microsoft.AspNetCore.Mvc;
using StoreData.Models;
using StoreData.Repostiroties;
using WebStoryFroEveryting.Controllers.CustomAutorizeAttributes;
using WebStoryFroEveryting.Models.UnderwaterHuntersWorld;
using WebStoryFroEveryting.Services;
using WebStoryFroEveryting.Services.UnderwaterHunterServices;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace WebStoryFroEveryting.Controllers
{
    public class UnderwaterHunterController : Controller
    {
        private HuntersGenerator _huntersGenerator;
        private UnderwarterHunterRepository _hunterRepository;
        private UnderwarterHunterCommentRepository _hunterCommentRepository;
        private AuthService _authService;
        private IHostingEnvironment _hostingEnvironment;
        public UnderwaterHunterController(HuntersGenerator huntersGenerator,
                                           UnderwarterHunterRepository hunterRepository,
                                            UnderwarterHunterCommentRepository hunterCommentRepository,
                                             AuthService authService,
                                              IHostingEnvironment hostingEnvironment)
        {
            _huntersGenerator = huntersGenerator;
            _hunterRepository = hunterRepository;
            _hunterCommentRepository = hunterCommentRepository;
            _authService = authService;
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index(string? tag)
        {
            var hunterDatas = _hunterRepository.GetAllHuntersAndTags(tag);
            if (!hunterDatas.Any())
            {
                var huntData = GetHuntersFromHunterGenerator();
                huntData.ForEach(x => _hunterRepository.Add(x));
                hunterDatas = _hunterRepository.GetAll();
            }
            var viewModel = new HunterIndexViewModel();
            viewModel.Hunters = hunterDatas.Select(ChangeBaseDataTypeToViewModelTypes).ToList();
            viewModel.Tags = hunterDatas
                .SelectMany(x => x.Tags)
                .Select(x => x.Tag)
                .Distinct()
                .ToList();
            viewModel.isAuthenticated = _authService.IsAuthenticated();
            viewModel.Author = _authService.GetUserName();
            return View(viewModel);
        }
        [HttpGet]
        [HasPermission(Permisson.CanCreatHunter)]
        public IActionResult CreateNewHunter()
        {
            var viewModel = new CreateUnderwaterHunterModel();
            viewModel.isAuthenticated = _authService.IsAuthenticated();

            return View(viewModel);
        }

        [HttpPost]
        [HasPermission(Permisson.CanCreatHunter)]
        public IActionResult CreateNewHunter(CreateUnderwaterHunterModel hunterModel)
        {
            if (!ModelState.IsValid)
            {
                hunterModel.isAuthenticated = _authService.IsAuthenticated();
                return View(hunterModel);
            }
            _hunterRepository.Add(new UnderwaterHunterData
            {
                NameHunter = hunterModel.NameHunter,
                Nationality = hunterModel.Nationality,
                MaxHuntingDepth = hunterModel.MaxHuntingDepth,
                Src = hunterModel.Image
            });

            return RedirectToAction(nameof(Index));
        }
        public IActionResult Remove(int id)
        {
            _hunterRepository.Remove(id);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult CommentHunter(int id)
        {
            var hunter = _hunterRepository.GetHunterWithCommentAndTag(id);
            var viewModel = new CommentHunterViewModel
            {
                Id = hunter.Id,
                Src = hunter.Src,
                Name = hunter.NameHunter,
                Comments = hunter.Comments
                .Select(x => new UnderwaterHunterCommentViewModel
                {
                    Id = x.Id,
                    Comment = x.Comment,
                    Created = x.Create
                })
                .ToList()

            };

            viewModel.Tags = hunter.Tags
                .Select(x => x.Tag)
                .ToList();
            viewModel.Author = _authService.GetUserName();
            viewModel.AuthorId = _authService.GetUserId();

            viewModel.CommentsWithoutDuplicates = _hunterCommentRepository
                .ShowCommentsWithoutDuplicates()
                .Select(x => new HunterCommentsWithoutDuplicatesViewModel
                {
                    Comment = x.Comment,
                    UserName = x.UserName
                })
                .ToList();

            return View(viewModel);
        }
        [HttpPost]
        public IActionResult AddTagHunter(int id, string tag)
        {
            _hunterRepository.AddTag(id, tag);
            return RedirectToAction(nameof(CommentHunter), new { id });
        }
        [HttpPost]
        public IActionResult AddCommentForHunter(int id, string comment, int authorId)
        {

            _hunterCommentRepository.AddComment(id, comment, authorId);
            return RedirectToAction(nameof(CommentHunter), new { id });
        }
        public IActionResult UpdateLikeUserPhoto(IFormFile photo)
        {         
            var webRootPath = _hostingEnvironment.WebRootPath;
            var fileName = $"photo.jpg";
            var path = Path.Combine(webRootPath, "imgForHunterPage", fileName);           
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                photo.CopyTo(fileStream);
            }

            return RedirectToAction(nameof(Index));
        }
        private List<UnderwaterHunterData> GetHuntersFromHunterGenerator()
        {
            var huntersD = _huntersGenerator
                    .GenerateHunters()
                    .Select(viewModel =>
                    new UnderwaterHunterData
                    {
                        Id = viewModel.Id,
                        NameHunter = viewModel.NameHunter,
                        MaxHuntingDepth = viewModel.MaxHuntingDepth,
                        Nationality = viewModel.Nationality,
                        Src = viewModel.Src,
                    })
                    .ToList();
            return huntersD;
        }
        private UnderwaterHunterViewModel ChangeBaseDataTypeToViewModelTypes(UnderwaterHunterData hunterData)
        {
            var hunter = new UnderwaterHunterViewModel()
            {
                Id = hunterData.Id,
                NameHunter = hunterData.NameHunter,
                MaxHuntingDepth = hunterData.MaxHuntingDepth,
                Nationality = hunterData.Nationality,
                Src = hunterData.Src,
                LikesCount = hunterData.LikesCount,
                DislikesCount = hunterData.DislikesCount
            };
            return hunter;
        }        
    }
}
