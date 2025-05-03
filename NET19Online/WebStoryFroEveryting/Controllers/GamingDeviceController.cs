using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StoreData.Models;
using StoreData.Repostiroties;
using WebStoryFroEveryting.Models.GamingDevice;
using WebStoryFroEveryting.Services;

namespace WebStoryFroEveryting.Controllers
{
    public class GamingDeviceController : Controller
    {
        private GamingDeviceRepository _gamingDeviceRepository;
        private IUserRepository _userRepository;
        private GamingDeviceReviewRepository _gamingDeviceReviewRepository;
        private AuthService _authService;

        public GamingDeviceController(
            GamingDeviceRepository gamingDeviceRepository,
            GamingDeviceGenerator gamingDeviceGenerator,
            GamingDeviceReviewRepository gamingDeviceReviewRepository,
            AuthService authService,
            IUserRepository userRepository)
        {
            _gamingDeviceRepository = gamingDeviceRepository;
            _gamingDeviceReviewRepository = gamingDeviceReviewRepository;
            _authService = authService;
            _userRepository = userRepository;
        }

        public IActionResult Index(string? stockAddress)
        {
            var gamingDeviceDatas = _gamingDeviceRepository.GetAllWithStock();

            var viewModel = new GamingDeviceIndexViewModel();
            viewModel.Devices = gamingDeviceDatas.Select(Map).ToList();
            viewModel.StockAdresses = gamingDeviceDatas
                .SelectMany(x => x.Stocks)
                .Select(x => x.Address)
                .Distinct()
                .ToList();
            viewModel.CurrentStockAddress = stockAddress;
            viewModel.CanUserFillters = _authService.IsAuthenticated();
            return View(viewModel);
        }

        [Authorize]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult CreateGamingDevice(GamingDeviceViewModel gamingDeviceViewModel)
        {
            _gamingDeviceRepository.Add(
                new GamingDeviceData
                {
                    Name = gamingDeviceViewModel.Name,
                    Brand = gamingDeviceViewModel.Brand,
                    Price = gamingDeviceViewModel.Price,
                    Src = gamingDeviceViewModel.Src,
                });

            return RedirectToAction(nameof(Index));
        }

        public IActionResult ReviewForGamingDevice(int deviceId)
        {
            var viewModel = new GamingDeviceWithReviewViewModel();

            var device = _gamingDeviceRepository.GetWithReviewsAndStocks(deviceId);

            viewModel.Id = device.Id;
            viewModel.Src = device.Src;
            viewModel.Reviews = device
                .Reviews
                .Select(x => new GamingDeviceReviewViewModel
                {
                    Id = x.Id,
                    Review = x.Review,
                    Created = x.Created
                })
                .ToList();
            viewModel.StockAddresses = device.Stocks.Select(x => x.Address).ToList();
            viewModel.CanUserLeaveReview = _authService.IsAuthenticated();

            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public IActionResult AddReview(int deviceId, string review)
        {
            _gamingDeviceReviewRepository.AddReview(deviceId, review);

            return RedirectToAction(nameof(ReviewForGamingDevice), new { deviceId });
        }

        [HttpPost]
        public IActionResult AddStockAddress(int deviceId, string stockAddress)
        {
            _gamingDeviceRepository.AddStock(deviceId, stockAddress);

            return RedirectToAction(nameof(ReviewForGamingDevice), new { deviceId });
        }

        public IActionResult RemoveGamingDevice(int deviceId)
        {
            _gamingDeviceRepository.Remove(deviceId);
            return RedirectToAction(nameof(Index));
        }

        private GamingDeviceViewModel Map(GamingDeviceData gamingDevice)
        {
            return new GamingDeviceViewModel
            {
                Id = gamingDevice.Id,
                Name = gamingDevice.Name,
                Brand = gamingDevice.Brand,
                Price = gamingDevice.Price,
                Src = gamingDevice.Src
            };
        }

    }
}
