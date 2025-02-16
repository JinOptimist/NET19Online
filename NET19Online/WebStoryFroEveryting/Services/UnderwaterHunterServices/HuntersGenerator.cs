using WebStoryFroEveryting.Models.UnderwaterHuntersWorld;

namespace WebStoryFroEveryting.Services.UnderwaterHunterServices
{
    public class HuntersGenerator
    {
        private TheBestUnderwaterHunters _theBestUnderwaterHunters;

        public HuntersGenerator(TheBestUnderwaterHunters theBestUnderwaterHunters)
        {
            _theBestUnderwaterHunters = theBestUnderwaterHunters;
        }

        public List<TheBestUnderwaterHunters> GenerateHunters()
        {
            var hunters = new List<TheBestUnderwaterHunters>
            {
                new TheBestUnderwaterHunters
                {
                    NameHunter="Pedro Carbonell",
                    Nationality = "Spanish",
                    MaxHuntingDepth= 40,
                    Src = "https://avatars.mds.yandex.net/i?id=d37489e48b123dee24adcce63e1304a5_l-5312143-images-thumbs&n=13"
                },
                new TheBestUnderwaterHunters
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
