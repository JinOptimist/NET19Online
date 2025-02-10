using Microsoft.AspNetCore.Mvc;
using WebStoryFroEveryting.Models.MagicItem;

namespace WebStoryFroEveryting.Controllers
{
    public class MagicItemController : Controller
    {
        public IActionResult CreateOrderForMagicItem()
        {
            var viewModels = new List<MagicItemViewModel>
            {
                new MagicItemViewModel
                {
                    Name = "Health elixir",
                    Src = "https://i.pinimg.com/236x/26/38/5b/26385b0941e3089e4ff0d48ecf61f14b.jpg",
                    Price = 20,
                    Category = "Elixirs"
                },
                new MagicItemViewModel
                {
                    Name = "Magic grimoire",
                    Src = "https://image.tensorartassets.com/model_showcase/719911023877901009/046bc9f6-8188-cf34-099d-5d9be384bc7c.jpeg",
                    Price = 100,
                    Category = "Books"
                },
                new MagicItemViewModel
                {
                    Name = "Ring of Fire",
                    Src = "https://i.pinimg.com/736x/bd/b7/31/bdb731f4824b3c4f270cea0797973255.jpg",
                    Price = 40,
                    Category = "Rings"
                },
                new MagicItemViewModel
                {
                    Name = "Teleport ring",
                    Src = "https://img.freepik.com/premium-photo/fantasy-ring-magic-jewelry-witch-wizard-ai-art-game-icon_154797-750.jpg",
                    Price = 120,
                    Category = "Rings"
                },
                new MagicItemViewModel
                {
                    Name = "Magic bag",
                    Src = "https://i.pinimg.com/736x/d0/88/10/d08810228dc39eaccc51ddc11b47e80d.jpg",
                    Price = 80,
                    Category = "Equipment"
                },
                new MagicItemViewModel
                {
                    Name = "Unlimited Scroll",
                    Src = "https://i.pinimg.com/736x/7f/28/7a/7f287ab2f1461e7e1411a0d4e7327c2c.jpg",
                    Price = 25,
                    Category = "Scrolls"
                }
            };
            return View(viewModels);
        }
    }
}
