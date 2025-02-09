using Microsoft.AspNetCore.Mvc;
using WebStoryFroEveryting.Models.SweetsModel;


namespace WebStoryFroEveryting.Controllers
{
    public class SweetsStoreController : Controller
    {
        public IActionResult CreateOrderForSweets()
        {
            var viewModels = new List<SweetsViewModel>
            {
                new SweetsViewModel
                {
                    Name = "Наполеон",
                    Src  = "https://media.ovkuse.ru/images/recipes/00dd49ad-83ee-41f5-841e-868f4e007cc0/00dd49ad-83ee-41f5-841e-868f4e007cc0_420_420.webp"
                },
                new SweetsViewModel
                {
                    Name = "Медовик",
                    Src  = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQBmzA16qgonkmWCK7ju7IrRbMolAnCwkl55A&s"
                },
                 new SweetsViewModel
                {
                    Name = "Тирамису",
                    Src  = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQoQxV4h7NEOxJrKs7nXku9FIBSeGMOeI7ELA&s"
                },
                
            };

            return View(viewModels);
        }
    }
    
}
