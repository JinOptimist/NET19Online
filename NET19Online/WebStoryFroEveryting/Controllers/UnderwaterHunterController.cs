using Microsoft.AspNetCore.Mvc;
using StoreData.Models;
using StoreData.Repostiroties;
using WebStoryFroEveryting.Models.UnderwaterHuntersWorld;
using WebStoryFroEveryting.Services.UnderwaterHunterServices;

namespace WebStoryFroEveryting.Controllers
{
    public class UnderwaterHunterController : Controller
    {
        private HuntersGenerator _huntersGenerator;
        private UnderwarterHunterRepository _hunterRepository;

        public UnderwaterHunterController(HuntersGenerator huntersGenerator, UnderwarterHunterRepository hunterRepository)
        {
            _huntersGenerator = huntersGenerator;
            _hunterRepository = hunterRepository;
        }
        public IActionResult CreatePageUnderwaterHunter()
        {
            var hunterDatas = _hunterRepository.GetAll();
            if (!hunterDatas.Any())
            {
                var huntData = GetHuntersFromHunterGenerator();
                huntData.ForEach(x => _hunterRepository.Add(x));
                hunterDatas = _hunterRepository.GetAll();
            }
            var viewModel = hunterDatas.Select(ChangeBaseDataTypeToViewModelTypes).ToList();
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult CreateNewHunter()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateNewHunter(CreateUnderwaterHunterModel hunterModel)
        {
            _hunterRepository.Add(new UnderwaterHunterData
            {
                NameHunter = hunterModel.NameHunter,
                Nationality = hunterModel.Nationality,
                MaxHuntingDepth = hunterModel.MaxHuntingDepth,
                Src = hunterModel.Image
            });
            return RedirectToAction(nameof(CreatePageUnderwaterHunter));
        }
        public IActionResult Remove(int id)
        {
            _hunterRepository.Remove(id);
            return RedirectToAction(nameof(CreatePageUnderwaterHunter));
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
        private TheBestUnderwaterHunters ChangeBaseDataTypeToViewModelTypes(UnderwaterHunterData hunterData)
        {
            var hunter = new TheBestUnderwaterHunters
            {
                Id = hunterData.Id,
                NameHunter = hunterData.NameHunter,
                MaxHuntingDepth = hunterData.MaxHuntingDepth,
                Nationality = hunterData.Nationality,
                Src = hunterData.Src,
            };
            return hunter;
        }
    }
}
