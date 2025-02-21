using Microsoft.AspNetCore.Mvc;
using WebStoryFroEveryting.Models.Home;
using WebStoryFroEveryting.Services;

namespace WebStoryFroEveryting.Controllers
{
    public class HomeController : Controller
    {
        private AuthService _authService;

        public HomeController(AuthService authService)
        {
            _authService = authService;
        }

        public IActionResult Index()
        {
            var userName = _authService.GetUserName();
            var indexViewModel = new IndexViewModel
            {
                UserName = userName
            };
            return View(indexViewModel);
        }

        public IActionResult Privacy(string name, int a, int b)
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
