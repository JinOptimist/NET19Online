using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using StoreData.Models;
using StoreData.Repostiroties;
using WebStoryFroEveryting.Hubs;
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
        private IHubContext<GamingDeviceHub, IGamingDeviceHub> _hubContext;

        public GamingDeviceController(
            GamingDeviceRepository gamingDeviceRepository,
            GamingDeviceGenerator gamingDeviceGenerator,
            GamingDeviceReviewRepository gamingDeviceReviewRepository,
            AuthService authService,
            IUserRepository userRepository,
            IHubContext<GamingDeviceHub, IGamingDeviceHub> hubContext)
        {
            _gamingDeviceRepository = gamingDeviceRepository;
            _gamingDeviceReviewRepository = gamingDeviceReviewRepository;
            _authService = authService;
            _userRepository = userRepository;
            _hubContext = hubContext;
        }

        private static List<int> CartItems = new List<int>();

        public IActionResult Index(string? stockAddress)
        {
            var gamingDeviceDatas = _gamingDeviceRepository.GetAllWithStock(stockAddress);

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

        [HttpGet("Cart/GetCartDevices")]
        public IActionResult GetCartDevices()
        {
            var cartItemIds = CartItems;

            var devicesInCart = _gamingDeviceRepository.GetDevicesByIds(cartItemIds);

            var viewModel = devicesInCart.Select(d => new GamingDeviceViewModel
            {
                Id = d.Id,
                Name = d.Name,
                Brand = d.Brand,
                Price = d.Price,
                Src = d.Src
            });

            return Json(viewModel);
        }

        [HttpPost("Cart/AddToCart")]
        public IActionResult AddToCart([FromBody] ProductIdsModel model)
        {
            foreach (var id in model.ProductIds)
            {
                CartItems.Add(id);
            }

            return Json(new { total = CartItems.Count });
        }

        [Authorize]
        [HttpPost("AddDevice")]
        public IActionResult AddDevice([FromBody] GamingDeviceViewModel gamingDeviceViewModel)
        {
            var device = _gamingDeviceRepository.AddDevice(
                new GamingDeviceData
                {
                    Name = gamingDeviceViewModel.Name,
                    Brand = gamingDeviceViewModel.Brand,
                    Price = gamingDeviceViewModel.Price,
                    Src = gamingDeviceViewModel.Src,
                });

            _hubContext.Clients.All.GamingDeviceWasAdded(device);
            return Json(device);
        }

        public IActionResult GamingDevice(int deviceId)
        {
            var viewModel = new GamingDeviceDetailsViewModel();

            var device = _gamingDeviceRepository.GetWithReviewsAndStocks(deviceId);

            viewModel.Id = device.Id;
            viewModel.Name = device.Name;
            viewModel.Brand = device.Brand;
            viewModel.Price = device.Price;
            viewModel.Src = device.Src;
            viewModel.Reviews = device
                .Reviews
                .Select(x => new GamingDeviceReviewViewModel
                {
                    Id = x.Id,
                    Review = x.Review,
                    Created = x.Created,
                    AuthorName = x.Author?.UserName ?? "unnamed"
                })
                .ToList();
            viewModel.StockAddresses = device.Stocks.Select(x => new GamingDeviceStockAddressesViewModel
            {
                Id = x.Id,
                Address = x.Address
            }).ToList();
            viewModel.CanUserLeaveReview = _authService.IsAuthenticated();

            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public IActionResult AddReview(int deviceId, string review)
        {
            var authorId = _authService.GetUserId();

            _gamingDeviceReviewRepository.AddReview(deviceId, review, authorId);

            return RedirectToAction(nameof(GamingDevice), new { deviceId });
        }

        [Authorize]
        [HttpPost]
        public IActionResult RemoveDuplicateReviews(int deviceId)
        {
            _gamingDeviceReviewRepository.RemoveDuplicateReviews(deviceId);

            return RedirectToAction(nameof(GamingDevice), new { deviceId });
        }

        [HttpPost]
        public IActionResult AddStockAddress(int deviceId, string stockAddress)
        {
            _gamingDeviceRepository.AddStockToDevice(deviceId, stockAddress);

            return RedirectToAction(nameof(GamingDevice), new { deviceId });
        }

        [HttpDelete("{deviceId}/StockAddresses/{stockAddressId}/Remove")]
        public IActionResult RemoveStockAddress(int deviceId, int stockAddressId)
        {
            _gamingDeviceRepository.RemoveStockFromDevice(deviceId, stockAddressId);

            return Ok();
        }

        [HttpPut("{deviceId}/StockAddresses/{stockAddressId}/Update")]
        public IActionResult UpdateStockAddress(int deviceId, int stockAddressId, [FromBody] string newStockAddress)
        {
            _gamingDeviceRepository.UpdateDeviceStock(deviceId, stockAddressId, newStockAddress);

            return Ok();
        }

        [HttpDelete("Remove/{deviceId}")]
        public IActionResult RemoveGamingDevice(int deviceId)
        {
             _gamingDeviceRepository.Remove(deviceId);
             _hubContext.Clients.All.GamingDeviceWasRemoved(deviceId);

            return Ok();
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
