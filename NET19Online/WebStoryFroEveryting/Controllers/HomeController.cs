using Microsoft.AspNetCore.Mvc;
using WebStoryFroEveryting.Models.Home;

namespace WebStoryFroEveryting.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult PurchaseFilms(string name, int a, int b)
        {
            //var second = DateTime.Now.Second * 2;
            // var name = "Ivan";

            var viewModel = new PrivacyViewModel
            {
                MagicNumber = a + b,
                Name = name,
            };
            return View(viewModel);
        }



    }
}
