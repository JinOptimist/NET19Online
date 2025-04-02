using StoreData.Models;
using WebStoryFroEveryting.Models.UnderwaterHuntersWorld;
using WebStoryFroEveryting.Services.UnderwaterHunterServices.Interfaces;

namespace WebStoryFroEveryting.Services.UnderwaterHunterServices
{
    public class HuntersGenerator
    {
        private HunterCreator _hunterCreator;
        public HuntersGenerator()
        {
            var huntersNumber = new HuntersNumber();
            _hunterCreator = new HunterCreator(huntersNumber);
        }
        public List<UnderwaterHunterData> GenerateHunter()
        {
            var huntersVM = _hunterCreator.CreateHunter();

            var hunterData = huntersVM.Select(viewModel =>
                 new UnderwaterHunterData
                 {
                     Id = viewModel.Id,
                     NameHunter = viewModel.NameHunter,
                     MaxHuntingDepth = viewModel.MaxHuntingDepth,
                     Nationality = viewModel.Nationality,
                     Src = viewModel.Src,
                 })
                 .ToList();

            return hunterData;
        }
    }
}
