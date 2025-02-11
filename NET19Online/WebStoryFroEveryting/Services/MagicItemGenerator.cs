using WebStoryFroEveryting.Models.MagicItem;

namespace WebStoryFroEveryting.Services
{
    public class MagicItemGenerator
    {
        private MagicItemNameGenerator _nameGenerator;
        private MagicItemCategoryGenerator _categoryGenerator;
        private Random _random = new();

        private List<string> Images = new()
        {
            "https://i.pinimg.com/236x/26/38/5b/26385b0941e3089e4ff0d48ecf61f14b.jpg",
            "https://image.tensorartassets.com/model_showcase/719911023877901009/046bc9f6-8188-cf34-099d-5d9be384bc7c.jpeg",
            "https://i.pinimg.com/736x/bd/b7/31/bdb731f4824b3c4f270cea0797973255.jpg",
            "https://img.freepik.com/premium-photo/fantasy-ring-magic-jewelry-witch-wizard-ai-art-game-icon_154797-750.jpg",
            "https://i.pinimg.com/736x/d0/88/10/d08810228dc39eaccc51ddc11b47e80d.jpg",
            "https://i.pinimg.com/736x/7f/28/7a/7f287ab2f1461e7e1411a0d4e7327c2c.jpg"
        };
        private List<decimal> Prices = new()
        {
            20,
            50,
            49.9m,
            100,
            90
        };

        public MagicItemGenerator(MagicItemNameGenerator nameGenerator, MagicItemCategoryGenerator categoryGenerator)
        {
            _nameGenerator = nameGenerator;
            _categoryGenerator = categoryGenerator;
        }

        public List<MagicItemViewModel> GenerateMagicItems(int count)
        {
            var list = new List<MagicItemViewModel>();

            for (int i = 0; i < count; i++)
            {
                var randomImagesIndex = _random.Next(Images.Count);
                var randomPricesIndex = _random.Next(Prices.Count);
                var item = new MagicItemViewModel
                {
                    Name = _nameGenerator.GetRandomName(),
                    Category = _categoryGenerator.GetRandomCategory(),
                    Src = Images[randomImagesIndex],
                    Price = Prices[randomPricesIndex]
                };
                list.Add(item);
            }

            return list;
        }
    }
}
