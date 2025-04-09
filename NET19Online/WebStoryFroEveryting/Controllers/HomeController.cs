using Enums.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StoreData.Repostiroties;
using System.Globalization;
using System.Linq;
using System.Reflection;
using WebStoryFroEveryting.Models.Home;
using WebStoryFroEveryting.Services;
using WebStoryFroEveryting.Services.Apis;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace WebStoryFroEveryting.Controllers
{
    public class HomeController : Controller
    {
        private AuthService _authService;
        private IUserRepository _userRepository;
        private IHostingEnvironment _hostingEnvironment;
        private HttpNumberApi _httpNumberApi;
        private HttpJokerApi _httpJokerApi;
        private HttpWeatherApi _httpWeatherApi;

		public HomeController(AuthService authService,
			IUserRepository userRepository, 
            IHostingEnvironment hostingEnvironment, 
            HttpNumberApi httpNumberApi, 
            HttpJokerApi httpJokerApi, 
            HttpWeatherApi httpWeatherApi)
		{
			_authService = authService;
			_userRepository = userRepository;
			_hostingEnvironment = hostingEnvironment;
			_httpNumberApi = httpNumberApi;
			_httpJokerApi = httpJokerApi;
			_httpWeatherApi = httpWeatherApi;
		}

		public async Task<IActionResult> Index()
        {
            var userName = _authService.GetUserName();

            var taskNumberFact = _httpNumberApi.GetFactAboutNumberAsync(); // 0 sec
            var taskJoke = _httpJokerApi.GetJokeAsync(); // 0 sec
            var taskWeather = _httpWeatherApi.GetWeatherAsync();


			Task.WaitAll(taskJoke, taskNumberFact, taskWeather); // Max(3 sec, 5 sec)

			var indexViewModel = new IndexViewModel
            {
                UserName = userName,
                FactAboutNumber = taskNumberFact.Result,
                Joke = taskJoke.Result,
                WeatherTemperature = $"{taskWeather.Result.current.temperature_2m} {taskWeather.Result.current_units.temperature_2m}"
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

        public IActionResult UpdateAvatar(IFormFile avatar)
        {
            var userId = _authService.GetUserId();
            //D:\\git\\NET19Online\\NET19Online\\WebStoryFroEveryting\\wwwroot
            var webRootPath = _hostingEnvironment.WebRootPath;
            var fileName = $"avatar-{userId}.jpg";
            var path = Path.Combine(webRootPath, "avatars", fileName);

            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                avatar.CopyTo(fileStream);
            }


            return RedirectToAction(nameof(Profile));
        }
    }
}
