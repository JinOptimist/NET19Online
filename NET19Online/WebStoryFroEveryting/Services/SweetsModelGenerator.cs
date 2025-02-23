using WebStoryFroEveryting.Models.AnimeGirl;
using WebStoryFroEveryting.Models.SweetsModel;

namespace WebStoryFroEveryting.Services
{
    public class SweetsModelGenerator
    {
        private SweetsNameGenerator _nameGenerator;

        private List<string> Images = new()
        {
            "https://media.ovkuse.ru/images/recipes/00dd49ad-83ee-41f5-841e-868f4e007cc0/00dd49ad-83ee-41f5-841e-868f4e007cc0_420_420.webp",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQBmzA16qgonkmWCK7ju7IrRbMolAnCwkl55A&s",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQoQxV4h7NEOxJrKs7nXku9FIBSeGMOeI7ELA&s"
        };

        public SweetsModelGenerator(SweetsNameGenerator nameGenerator)
        {
            _nameGenerator = nameGenerator;
        }


        public List<SweetsViewModel> GenerateSweetsModel(int count)
        {
            var list = new List<SweetsViewModel>();
            var random = new Random();

            for (int i = 0; i < count; i++)
            {

                var randomImagesIndex = random.Next(Images.Count);
                var model = new SweetsViewModel
                {
                    Name = _nameGenerator.GetRandomName(),
                    Src = Images[randomImagesIndex]
                };
                list.Add(model);
            }

            return list;
        }
    }
}

