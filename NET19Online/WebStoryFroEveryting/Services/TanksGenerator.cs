using WebStoryFroEveryting.Models.Tanks;

namespace WebStoryFroEveryting.Services
{
    public class TanksGenerator
    {
       private NameGenerator _nameGenerator;

        private List<string> Images = new()
        {
            https://stalin-line.by/images/exposition/Tank_T34/uztm.jpg
            https://parkpatriot.ru/upload/iblock/86b/0A7A5187.JPG
            https://tanksdb.ru/images/tanks/tiger.jpg
            https://parkpatriot.ru/upload/iblock/30c/Pantera-vo-aremya-rekonstruktsii.jpg
        };


        public TanksGenerator(NameGenerator nameGenerator)
        {
            _nameGenerator = nameGenerator;
        }

        private List<TankViewModel> GenerateTanks(int count)
        {
            var list = new List<TankViewModel>();

            var random = new Random();
            for (int i = 0; i < count; i++)
            {
                
                var randomImagesIndex = random.Next(Images.Count);
                var tank = new TankViewModel
                {
                    Name = _nameGenerator.GetRandomName(),
                    Src = Images[randomImagesIndex]
                };
                list.Add(tank);
            }
            return list;
        }
    }
}
