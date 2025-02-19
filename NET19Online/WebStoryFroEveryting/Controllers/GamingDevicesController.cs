using Microsoft.AspNetCore.Mvc;
using StoreData.Models;
using StoreData.Repostiroties;
using WebStoryFroEveryting.Models.GamingDevice;
using WebStoryFroEveryting.Services;

namespace WebStoryFroEveryting.Controllers
{
    public class GamingDevicesController : Controller
    {
        private GamingDeviceGenerator _gamingDeviceGenerator;
        private GamingDeviceRepository _gamingDeviceRepository;

        public GamingDevicesController(GamingDeviceRepository gamingDeviceRepository, GamingDeviceGenerator gamingDeviceGenerator)
        {
            _gamingDeviceRepository = gamingDeviceRepository;
            _gamingDeviceGenerator = gamingDeviceGenerator;
        }

        public IActionResult GetGamingDevices()
        {
            var gamingDeviceDatas = _gamingDeviceRepository.GetAll();
            if (!gamingDeviceDatas.Any())
            {
                _gamingDeviceGenerator
                    .GenerateDevices(4)
                    .Select(viewModel =>
                        new GamingDeviceData
                        {
                            Id = viewModel.Id,
                            Name = viewModel.Name,
                            Brand = viewModel.Brand,
                            Price = viewModel.Price,
                            Src = viewModel.Src
                        })
                    .ToList()
                    .ForEach(_gamingDeviceRepository.Add);
                gamingDeviceDatas = _gamingDeviceRepository.GetAll();
            }

            var viewModels = gamingDeviceDatas.Select(Map).ToList();
            return View(viewModels);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

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

            return RedirectToAction(nameof(GetGamingDevices));
        }

        public IActionResult RemoveGamingDevice(int id)
        {
            _gamingDeviceRepository.Remove(id);
            return RedirectToAction(nameof(GetGamingDevices));
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
