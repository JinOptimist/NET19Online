using Microsoft.AspNetCore.Mvc;
using WebStoryFroEveryting.Models.AnimeGirl;
using WebStoryFroEveryting.Models.GamingDevice;

namespace WebStoryFroEveryting.Controllers
{
    public class GamingDeviceController : Controller
    {
        public IActionResult CreateOrderForGamingDevice()
        {
            var viewModels = new List<GamingDeviceViewModel>
            {
                new GamingDeviceViewModel
                {
                    Name = "Игровая мышь DeathAdder Essential",
                    Brand = "Razer",
                    Price = 93.42m,
                    Src  = "https://img.5element.by/import/images/ut/goods/good_f3262a0f-ff6a-11eb-bb92-0050560120e8/rz01-03850100-r3m1-razer-igrovaya-mysh-deathadder-essential-1_600.jpg"
                },
                new GamingDeviceViewModel
                {
                    Name = "Клавиатура Alloy Origins",
                    Brand = "HyperX",
                    Price = 359.00m,
                    Src  = "https://img.5element.by/import/images/ut/goods/good_b4a38539-29f2-11ee-bb94-005056012463/4p4f6aa-aba-hx-kb6rdx-ru-klaviatura-hyperx-alloy-origins-1_600.jpg"
                },
                 new GamingDeviceViewModel
                {
                    Name = "Гарнитура G332",
                    Brand = "LOGITECH",
                    Price = 265.00m,
                    Src  = "https://img.5element.by/import/images/ut/goods/good_4fb9b46b-9678-11e9-80c7-005056840c70/g332-l981-000757-igrovaya-garnitura-logitech-1_600.jpg"
                },
                new GamingDeviceViewModel
                {
                    Name = "Игровой коврик QcK Hard Pad",
                    Brand = "STEELSERIES",
                    Price = 65.40m,
                    Src  = "https://img.5element.by/import/images/ut/goods/good_b4dbdecc-292e-11e9-80c7-005056840c70/good_img_0aa4b720-30ec-11e9-80c7-005056840c70_600.jpg"
                }
            };

            return View(viewModels);
        }
    }
}
