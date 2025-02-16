using Microsoft.AspNetCore.Mvc;
using StoreData.Models;
using StoreData.Repostiroties;
using WebStoryFroEveryting.Models.MagicItem;
using WebStoryFroEveryting.Services;

namespace WebStoryFroEveryting.Controllers
{
    public class MagicItemController : Controller
    {
        private MagicItemGenerator _magicItemGenerator;
        private MagicItemRepository _magicItemRepository;

        public MagicItemController(MagicItemGenerator magicItemGenerator, MagicItemRepository magicItemRepository)
        {
            _magicItemGenerator = magicItemGenerator;
            _magicItemRepository = magicItemRepository;
        }

        public IActionResult CreateOrderForMagicItem()
        {
            var magicItemsDatas = _magicItemRepository.GetAll();
            if (!magicItemsDatas.Any())
            {
                _magicItemGenerator
                    .GenerateMagicItems(5)
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

            var viewModels = magicItemsDatas.Select(Map).ToList();
            return View(viewModels);
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
            return RedirectToAction(nameof(CreateOrderForMagicItem));
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
