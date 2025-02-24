using Microsoft.AspNetCore.Mvc;
using StoreData;
using StoreData.Models;
using StoreData.Repostiroties;
using WebStoryFroEveryting.Models.SweetsModel;
using WebStoryFroEveryting.Services;


namespace WebStoryFroEveryting.Controllers
{
    public class SweetsStoreController : Controller
    {
        private SweetsModelGenerator _modelGenerator;
        private SweetsRepository _sweetsRepository;
        private SweetsCommentsRepository _sweetsCommentsRepository;

        public SweetsStoreController(SweetsModelGenerator modelGenerator, SweetsRepository sweetsRepository, SweetsCommentsRepository sweetsCommentsRepository)
        {
            _modelGenerator = modelGenerator;
            _sweetsRepository = sweetsRepository;
            _sweetsCommentsRepository = sweetsCommentsRepository;
        }


        public IActionResult CreateOrderForSweets()
        {
            var sweetsData = _sweetsRepository.GetAll();
            if (!sweetsData.Any())
            {
                _modelGenerator
                     .GenerateSweetsModel(4)
                     .Select(x =>
                     new SweetsData
                     {
                         Name = x.Name,
                         Src = x.Src
                     })
                     .ToList()
                     .ForEach(_sweetsRepository.Add);
                sweetsData = _sweetsRepository.GetAll();

            }
            var viewModels = sweetsData.Select(Map).ToList();

            return View(viewModels);
        }
        public IActionResult Remove(int id)
        {
            _sweetsRepository.Remove(id);
            return RedirectToAction(nameof(CreateOrderForSweets));

        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateSweetsViewModel viewModel)
        {
            _sweetsRepository.Add(
                new SweetsData
                {
                    Name = viewModel.Name,
                    Src = viewModel.Src
                });

            return RedirectToAction(nameof(CreateOrderForSweets));
        }
        public IActionResult CommentForSweets(int sweetsId)
        {
            var viewModel = new SweetsWithCommentViewModel();
            var sweets = _sweetsRepository.GetWithCommentsAndTags(sweetsId);
            viewModel.Id = sweets.Id;
            viewModel.Src = sweets.Src;
            viewModel.Comments = sweets
                .Comments
                .Select(x => new SweetsCommentViewModel
                {
                    Id = x.Id,
                    Comment = x.Comment,
                    Created = x.Created,
                })
                .ToList();
            viewModel.Tags = sweets.Tags.Select(x => x.Tag).ToList();
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult AddComment(int sweetsId, string comment)
        {
            _sweetsCommentsRepository.AddComment(sweetsId, comment);

            return RedirectToAction(nameof(CommentForSweets), new { sweetsId });
        }
        [HttpPost]
        public IActionResult AddTag(int sweetsId, string tag)
        {
            _sweetsRepository.AddTag(sweetsId, tag);

            return RedirectToAction(nameof(CommentForSweets), new { sweetsId });
        }
        private SweetsViewModel Map(SweetsData model)
        {
            return new SweetsViewModel

            {
                Id = model.Id,
                Src = model.Src,
                Name = model.Name,
            };
        }

    }

}
