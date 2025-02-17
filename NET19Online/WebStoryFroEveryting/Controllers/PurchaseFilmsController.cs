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
        private FilmsRepository _filmsRepository;
        private FilmsGeneratorServices _filmsGeneratorServices;

        public PurchaseFilmsController(FilmsRepository filmsRepository, FilmsGeneratorServices filmsGeneratorServices)
        {
            _filmsRepository = filmsRepository;
            _filmsGeneratorServices = filmsGeneratorServices;
        }
        public IActionResult CreatePurchaseFilms()
        {
            var items = _filmsRepository.GetAll();

            if (!items.Any())
            {
                _filmsGeneratorServices.GenerateFilms()
                  .Select(viewModel => new FilmData
                  {
                      Name = viewModel.Name,
                      Src = viewModel.Src,
                      Description = "Test"


                  }).ToList()
                  .ForEach(_filmsRepository.Add);
                items = _filmsRepository.GetAll();
            }


            var viewModels = items.Select(Map).ToList();
            return View(viewModels);
        }

        public IActionResult RemoveFilms(int id)
        {
            var items = _filmsRepository.Get(id);
            if (items is not null)
            {
                _filmsRepository.Remove(items);
            }
            return RedirectToAction(nameof(CreatePurchaseFilms));
        }

        private FilmsViewModel Map(FilmData date)
        {
            return new FilmsViewModel
            {
                Name = date.Name,
                Src = date.Src,
                FilmId = date.Id
            };
        }

        public IActionResult CreateFilms()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateFilms(CreateFilmsViewModel createFilmsViewModel)
        {

            _filmsRepository.Add(new FilmData
            {
                Name = createFilmsViewModel.Name,
                Src = createFilmsViewModel.Src,
                Description = "New"
            });

            return RedirectToAction(nameof(CreatePurchaseFilms));
        }



    }
}
