using Microsoft.AspNetCore.Mvc;
using WebStoryFroEveryting.Models.UnderwaterHuntersWorld;

namespace WebStoryFroEveryting.Controllers
{
    public class UnderwaterHunterController : Controller
    {
        public IActionResult CreatePageUnderwaterHunter()
        {
            var hunters = new List<TheBestUnderwaterHunters>
            {
                new TheBestUnderwaterHunters
                {
                    NameHunter="Pedro Carbonell",
                    Nationality = "Spanish",
                    maxHuntingDepth= 40,
                    Src = "https://avatars.mds.yandex.net/i?id=d37489e48b123dee24adcce63e1304a5_l-5312143-images-thumbs&n=13"
                },
                new TheBestUnderwaterHunters
                {
                    NameHunter="Gabriele Delbene",
                    Nationality = "Italian",
                    maxHuntingDepth= 62,
                    Src = "https://www.batiskaf.ru/media/wysiwyg/wordpress/2014/12/DSCN2440.jpg"
                }
            };
            return View(hunters);
        }
    }
}
