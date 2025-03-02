using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using StoreData.Models;
using StoreData.Repostiroties;
using System.Security.Claims;
using WebStoryFroEveryting.Models.Auth;
using WebStoryFroEveryting.Services;

namespace WebStoryFroEveryting.Controllers
{
    public class AuthController : Controller
    {
        private UserRepository _userRepository;

        public AuthController(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(AuthViewModel viewModel)
        {
            var user = _userRepository.Login(viewModel.UserName, viewModel.Password);

            if (user is null)
            {
                return RedirectToAction("Login");
            }

            var claims = new List<Claim>
            {
                new Claim(AuthService.CLAIM_KEY_ID, user.Id.ToString()),
                new Claim(AuthService.CLAIM_KEY_NAME, user.UserName.ToString()),
                new Claim(AuthService.CLAIM_KEY_PERMISSION, ((int?)user.Role?.Permisson ?? -1).ToString()),
                new Claim(ClaimTypes.AuthenticationMethod, AuthService.AUTH_TYPE)
            };

            var identity = new ClaimsIdentity(claims, AuthService.AUTH_TYPE);

            var principal = new ClaimsPrincipal(identity);

            HttpContext
                .SignInAsync(principal)
                .Wait();

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registration(AuthViewModel viewModel)
        {
            var isNameNotUniq = _userRepository.Any(viewModel.UserName);
            if (isNameNotUniq)
            {
                ModelState.AddModelError(nameof(AuthViewModel.UserName), "Not uniq name");
            }

            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            _userRepository.Registration(viewModel.UserName, viewModel.Password);

            return RedirectToAction("Login");
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync().Wait();
            return RedirectToAction("Index", "Home");
        }
    }
}
