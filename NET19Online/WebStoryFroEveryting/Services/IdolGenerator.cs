using WebStoryFroEveryting.Models.AnimeGirl;
using WebStoryFroEveryting.Services.ReflectionServices;

namespace WebStoryFroEveryting.Services
{
    public class IdolGenerator
    {
        private NameGenerator _nameGenerator;
        private string _defaultName;
        private Random _random = new();

        private List<string> Images = new()
        {
            "https://e7.pngegg.com/pngimages/695/533/png-clipart-brown-haired-female-anime-character-wearing-black-uniform-yuki-cross-kaname-kuran-zero-kiryu-vampire-knight-vampire-black-hair-manga.png",
            "https://c4.wallpaperflare.com/wallpaper/48/394/450/swordartonline-anime-girls-kirito-sword-art-online-asuna-sword-art-online-hd-wallpaper-preview.jpg",
            "https://static1.cbrimages.com/wordpress/wp-content/uploads/2020/03/CBR-Featured-Images-Albedo-Overlord.jpg",
            "https://i.pinimg.com/736x/10/0d/8b/100d8b296e190447218e773bdb3e5e77.jpg"
        };

        [AutoRegistration]
        public IdolGenerator(NameGenerator nameGenerator)
        {
            _nameGenerator = nameGenerator;
        }

        public IdolGenerator(string defaultName)
        {
            _defaultName = defaultName;
        }

        public List<IdolViewModel> GenerateIdols(int count)
        {
            var list = new List<IdolViewModel>();

            for (int i = 0; i < count; i++)
            {
                var randomImagesIndex = _random.Next(Images.Count);
                var idol = new IdolViewModel
                {
                    Name = _nameGenerator?.GetRandomName() ?? _defaultName,
                    Src = Images[randomImagesIndex]
                };
                list.Add(idol);
            }

            return list;
        }
    }
}
