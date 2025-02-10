using Microsoft.AspNetCore.Mvc;
using WebStoryFroEveryting.Models.AnimeGirl;

namespace WebStoryFroEveryting.Controllers
{
    public class AnimeGirlController : Controller
    {
        public IActionResult CreateOrderForAnimeGirl()
        {
            var viewModels = new List<IdolViewModel>
            {
                new IdolViewModel
                {
                    Name = "Юки",
                    Src  = "https://e7.pngegg.com/pngimages/695/533/png-clipart-brown-haired-female-anime-character-wearing-black-uniform-yuki-cross-kaname-kuran-zero-kiryu-vampire-knight-vampire-black-hair-manga.png"
                },
                new IdolViewModel
                {
                    Name = "Кирито",
                    Src  = "https://c4.wallpaperflare.com/wallpaper/48/394/450/swordartonline-anime-girls-kirito-sword-art-online-asuna-sword-art-online-hd-wallpaper-preview.jpg"
                },
                 new IdolViewModel
                {
                    Name = "Юки 3",
                    Src  = "https://e7.pngegg.com/pngimages/695/533/png-clipart-brown-haired-female-anime-character-wearing-black-uniform-yuki-cross-kaname-kuran-zero-kiryu-vampire-knight-vampire-black-hair-manga.png"
                },
                new IdolViewModel
                {
                    Name = "Overlord",
                    Src  = "https://static1.cbrimages.com/wordpress/wp-content/uploads/2020/03/CBR-Featured-Images-Albedo-Overlord.jpg"
                },
                new IdolViewModel
                {
                    Name = "Riven",
                    Src  = "https://i.pinimg.com/736x/10/0d/8b/100d8b296e190447218e773bdb3e5e77.jpg"
                }
            };

            return View(viewModels);
        }
    }
}
