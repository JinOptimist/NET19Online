using Enums.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StoreData.Models;
using StoreData.Repostiroties;
using WebStoryFroEveryting.Controllers.CustomAutorizeAttributes;
using WebStoryFroEveryting.Models.AnimeGirl;
using WebStoryFroEveryting.Services;

namespace WebStoryFroEveryting.Controllers
{
    public class AnimeGirlController : Controller
    {
        private IdolGenerator _idolGenerator;
        private IdolRepository _idolRepository;
        private UserRepository _userRepository;
        private IdolCommentRepository _idolCommentRepository;
        private AuthService _authService;

        public AnimeGirlController(IdolGenerator idolGenerator,
            IdolRepository idolRepository,
            IdolCommentRepository idolCommentRepository,
            AuthService authService,
            UserRepository userRepository)
        {
            _idolGenerator = idolGenerator;
            _idolRepository = idolRepository;
            _idolCommentRepository = idolCommentRepository;
            _authService = authService;
            _userRepository = userRepository;
        }

        public IActionResult Index(string? tag)
        {
            var idolDatas = _idolRepository.GetAllWithTags(tag);
            if (!idolDatas.Any())
            {
                _idolGenerator
                    .GenerateIdols(5)
                    .Select(viewModel =>
                        new IdolData
                        {
                            Name = viewModel.Name,
                            Src = viewModel.Src
                        })
                    .ToList()
                    .ForEach(_idolRepository.Add);
                idolDatas = _idolRepository.GetAll();
            }

            var viewModel = new IdolIndexViewModel();
            viewModel.Idols = idolDatas.Select(Map).ToList();
            viewModel.Tags = idolDatas
                .SelectMany(x => x.Tags)
                .Select(x => x.Tag)
                .Distinct()
                .ToList();
            viewModel.CurrentTag = tag;
            viewModel.CanUserFillters = _authService.IsAuthenticated();

            viewModel.UserAndIdolsAges = _userRepository
                .GetUserNamesWithAveIdolAge()
                .Select(x => new UserAndIdolsAgesViewModel
                {
                    AvgAge = x.AvgAge,
                    UserName = x.UserName
                })
                .ToList();

            return View(viewModel);
        }

        public IActionResult Remove(int id)
        {
            _idolRepository.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Authorize]
        [HasPermission(Permisson.CanAddIdol)]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        [HasPermission(Permisson.CanAddIdol)]
        public IActionResult Create(CreateIdolViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            _idolRepository.Add(
                new IdolData
                {
                    Name = viewModel.Name,
                    Src = viewModel.Src
                });
            return RedirectToAction(nameof(Index));
        }

        public IActionResult CommentForGirl(int idolId)
        {
            var viewModel = new IdolWithCommentViewModel();

            var idol = _idolRepository.GetWithCommentsAndTags(idolId);

            viewModel.Id = idol.Id;
            viewModel.Src = idol.Src;
            viewModel.Comments = idol
                .Comments
                .Select(x => new IdolCommentViewModel
                {
                    Id = x.Id,
                    Comment = x.Comment,
                    Created = x.Created
                })
                .ToList();
            viewModel.Tags = idol.Tags.Select(x => x.Tag).ToList();

            return View(viewModel);
        }

        [HttpPost]
        [HasPermission(Permisson.CanAddIdolComment)]
        public IActionResult AddComment(int idolId, string comment)
        {
            var authorId = _authService.GetUserId();
            _idolCommentRepository.AddComment(idolId, comment, authorId);

            return RedirectToAction(nameof(CommentForGirl), new { idolId });
        }

        [HttpPost]
        public IActionResult AddTag(int idolId, string tag)
        {
            _idolRepository.AddTag(idolId, tag);

            return RedirectToAction(nameof(CommentForGirl), new { idolId });
        }

        [HttpPost]
        public IActionResult BigRemove(string idsToRemove)
        {
            var ids = idsToRemove
                .Split(",")
                .Select(idStr => int.Parse(idStr));
            _idolRepository.Remove(ids);

            return RedirectToAction(nameof(Index));
        }

        private IdolViewModel Map(IdolData idol)
        {
            return new IdolViewModel
            {
                Id = idol.Id,
                Src = idol.Src,
                Name = idol.Name,
            };
        }
    }
}
