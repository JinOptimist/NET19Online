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
                }
            };

            return View(viewModels);
        }
    }
}
