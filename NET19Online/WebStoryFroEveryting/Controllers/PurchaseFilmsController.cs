using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreData.Models;
using StoreData.Repostiroties;
using WebStoryFroEveryting.Models.Films;
using WebStoryFroEveryting.Services.FilmsServer;

namespace WebStoryFroEveryting.Controllers
{
    public class PurchaseFilmsController : Controller
    {
        FilmsRepository _filmsRepository;
        FilmsGeneratorServices _filmsGeneratorServices;

        public PurchaseFilmsController(FilmsRepository filmsRepository, FilmsGeneratorServices filmsGeneratorServices)
        {
            _filmsRepository = filmsRepository;
            _filmsGeneratorServices = filmsGeneratorServices;
        }
        public IActionResult CreatePurchaseFilms()
        {
            var items = _filmsRepository.GetItems();

            if (!items.Any())
            {
                _filmsGeneratorServices.GenerateFilms()
                  .Select(viewModel => new FilmsDate
                  {
                      Name = viewModel.Name,
                      Src = viewModel.Src,
                  }).ToList()
                  .ForEach(_filmsRepository.AddFilml);
                items = _filmsRepository.GetItems();
            }


            var viewModels = items.Select(Map).ToList();
            return View(viewModels);
        }

        private FilmsViewModel Map(FilmsDate date)
        {
            return new FilmsViewModel
            { 
               Name=date.Name,
               Src=date.Src,
            };
        }

        public IActionResult CreateFilms()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateFilms(CreateFilmsViewModel createFilmsViewModel)
        {

            _filmsRepository.AddFilml(new FilmsDate
            {
                Name = createFilmsViewModel.Name,
                Src = createFilmsViewModel.Src
            });

            return RedirectToAction(nameof(CreatePurchaseFilms));
        }



    }
}
