using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using StoreData.Repostiroties;
using WebStoryFroEveryting.Models.Auth;
using WebStoryFroEveryting.Models.SchoolAuth;
using WebStoryFroEveryting.Services;

namespace WebStoryFroEveryting.Controllers;

public class SchoolAuthController : Controller
{
     private SchoolUserRepository _userRepository;
    
            public SchoolAuthController(SchoolUserRepository userRepository)
            {
                _userRepository = userRepository;
            }
    
            public IActionResult Login()
            {
                return View();
            }
    
            [HttpPost]
            public IActionResult Login(SchoolAuthViewModel viewModel)
            {
                var user = _userRepository.Login(viewModel.Username, viewModel.Password);
    
                if (user is null)
                {
                    return RedirectToAction("Login");
                }
    
                var claims = new List<Claim>
                {
                    new Claim(AuthService.CLAIM_KEY_ID, user.Id.ToString()),
                    new Claim(AuthService.CLAIM_KEY_NAME, user.Username.ToString()),
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
            public IActionResult Registration(SchoolAuthViewModel viewModel)
            {
                _userRepository.Registration(viewModel.Username,viewModel.Email, viewModel.Password);
                return RedirectToAction("Login");
            }
    
            public IActionResult Logout()
            {
                HttpContext.SignOutAsync().Wait();
                return RedirectToAction("Index", "Home");
            }
        
}