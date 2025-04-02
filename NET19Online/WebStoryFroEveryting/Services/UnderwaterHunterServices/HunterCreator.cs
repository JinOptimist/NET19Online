using WebStoryFroEveryting.Models.UnderwaterHuntersWorld;
using WebStoryFroEveryting.Services.UnderwaterHunterServices.Interfaces;

namespace WebStoryFroEveryting.Services.UnderwaterHunterServices
{
    public class HunterCreator
    {
        private IHuntersNumber _minHuntersNumber;

        public HunterCreator(IHuntersNumber minHuntersNumber)
        {
            _minHuntersNumber = minHuntersNumber;
        }
        public List<UnderwaterHunterViewModel> CreateHunter()
        {
            var minNumberOfHunters = _minHuntersNumber.GetMinHuntersNumber();

            if (minNumberOfHunters < 2)
            {
                throw new ArgumentException("The number of hunters must be more 1");
            }

            var hunters = new List<UnderwaterHunterViewModel>
            {
                new UnderwaterHunterViewModel
                {
                    NameHunter="Pedro Carbonell",
                    Nationality = "Spanish",
                    MaxHuntingDepth= 40,
                    Src = "https://avatars.mds.yandex.net/i?id=d37489e48b123dee24adcce63e1304a5_l-5312143-images-thumbs&n=13"
                },
                new UnderwaterHunterViewModel
                {
                    NameHunter="Gabriele Delbene",
                    Nationality = "Italian",
                    MaxHuntingDepth= 62,
                    Src = "https://www.batiskaf.ru/media/wysiwyg/wordpress/2014/12/DSCN2440.jpg"
                }
            };

            return hunters;
        }
    }
}
