using Microsoft.AspNetCore.Mvc;
using StoreData.Models;
using StoreData.Repostiroties;
using WebStoryFroEveryting.Models.AnimeGirl;
using WebStoryFroEveryting.Models.MagicItem;
using WebStoryFroEveryting.Services;

namespace WebStoryFroEveryting.Controllers
{
    public class MagicItemController : Controller
    {
        private MagicItemGenerator _magicItemGenerator;
        private MagicItemRepository _magicItemRepository;
        private MagicItemCommentRepository _magicItemCommentRepository;
        private AuthService _authService;


        public MagicItemController(MagicItemGenerator magicItemGenerator, 
               MagicItemRepository magicItemRepository,
               MagicItemCommentRepository magicItemCommentRepository,
               AuthService authService)
        {
            _magicItemGenerator = magicItemGenerator;
            _magicItemRepository = magicItemRepository;
            _magicItemCommentRepository = magicItemCommentRepository;
            _authService = authService;
        }

        public IActionResult Index(string? tag)
        {
            var magicItemsDatas = _magicItemRepository.GetAllWithTags(tag);
            if (!magicItemsDatas.Any())
            {
                _magicItemGenerator
                    .GenerateMagicItems(14)
                    .Select(viewModel =>
                        new MagicItemData
                        {
                            Name = viewModel.Name,
                            Src = viewModel.Src,
                            Description = viewModel.Description ?? "",
                            Category = viewModel.Category,
                            Price = viewModel.Price
                        })
                    .ToList()
                    .ForEach(_magicItemRepository.Add);
                magicItemsDatas = _magicItemRepository.GetAll();
            }

            var viewModel = new MagicItemIndexViewModel();
            viewModel.MagicItems = magicItemsDatas.Select(Map).ToList();
            viewModel.Tags = magicItemsDatas
                .SelectMany(x => x.Tags)
                .Select(x => x.Tag)
                .Distinct()
                .ToList();
            viewModel.CurrentTag = tag;
            viewModel.CanUserFillters = _authService.IsAuthenticated();
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateMagicItemViewModel viewModel)
        {
            _magicItemRepository.Add(
                new MagicItemData
                {
                    Name = viewModel.Name,
                    Src = viewModel.Src,
                    Category = viewModel.Category,
                    Price = viewModel.Price,
                    Description = viewModel.Description,
                    ItemsInStock = viewModel.ItemsInStock
                });
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Remove(int id)
        {
            _magicItemRepository.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult CommentForMagicItem(int magicItemId)
        {
            var viewModel = new MagicItemWithCommentViewModel();

            var magicItem = _magicItemRepository.GetWithCommentsAndTags(magicItemId);

            viewModel.Id = magicItem.Id;
            viewModel.Src = magicItem.Src;
            viewModel.Comments = magicItem
                .Comments
                .Select(x => new MagicItemCommentViewModel
                {
                    Id = x.Id,
                    Comment = x.Comment,
                    Created = x.Created
                })
                .ToList();
            viewModel.Tags = magicItem.Tags.Select(x => x.Tag).ToList();

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult AddComment(int magicItemId, string comment)
        {
            _magicItemCommentRepository.AddComment(magicItemId, comment);

            return RedirectToAction(nameof(CommentForMagicItem), new { magicItemId });
        }

        [HttpPost]
        public IActionResult AddTag(int magicItemId, string tag)
        {
            _magicItemRepository.AddTag(magicItemId, tag);

            return RedirectToAction(nameof(CommentForMagicItem), new { magicItemId });
        }


        private MagicItemViewModel Map(MagicItemData item)
        {
            return new MagicItemViewModel
            {
                Id = item.Id,
                Src = item.Src,
                Name = item.Name,
                Category = item.Category,
                Price = item.Price
            };
        }
    }
}
