using Enums.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StoreData.Repostiroties;
using System.Globalization;
using System.Linq;
using WebStoryFroEveryting.Models.Home;
using WebStoryFroEveryting.Services;

namespace WebStoryFroEveryting.Controllers
{
    public class HomeController : Controller
    {
        private AuthService _authService;
        private UserRepository _userRepository;

        public HomeController(AuthService authService, UserRepository userRepository)
        {
            _authService = authService;
            _userRepository = userRepository;
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

        public IActionResult Profile()
        {
            var userId = _authService.GetUserId();
            var user = _userRepository.Get(userId);

            var viewModel = new ProfileViewModel
            {
                UserLocale = user.Local,
                Id = userId,
                Name = user.UserName,
                AllLocales = Enum
                    .GetValues<UserLocale>()
                    .Select(local => new SelectListItem(
                        local.ToString(), 
                        ((int)local).ToString(),
                        local == user.Local)
                    )
                    .ToList()
            };

            return View(viewModel);
        }

        public IActionResult UpdateLocal(int id, UserLocale newLocal)
        {
            _userRepository.UpdateLocal(id, newLocal);
            return RedirectToAction(nameof(Profile));
        }
    }
}
