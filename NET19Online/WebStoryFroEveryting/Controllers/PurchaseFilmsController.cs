using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreData.Repostiroties;
using WebStoryFroEveryting.Models.Films;

namespace WebStoryFroEveryting.Controllers
{
    public class PurchaseFilmsController : Controller
    {
        FilmsRepository _filmsRepository;

        public PurchaseFilmsController(FilmsRepository filmsRepository)
        {
            _filmsRepository=filmsRepository;
        }

        public IActionResult CreateFilms()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateFilms(CreateFilmsViewModel createFilmsViewModel)
        {
               
            return View(createFilmsViewModel);
        }
        public IActionResult CreatePurchaseFilms()
        {
            var viewModels = new List<FilmsViewModel>
            {
               new FilmsViewModel
               {
                    Name = "Нация Z 1",
                    Src="https://www.film.ru/sites/default/files/styles/epsa_260x400/public/movies/posters/4677076-1076094.jpg"
               },
               new FilmsViewModel
               {
                    Name = "Нация Z 2",
                    Src="https://www.film.ru/sites/default/files/styles/epsa_260x400/public/movies/posters/4677076-1076094.jpg"
               },
               new FilmsViewModel
               {
                    Name = "Нация Z 3",
                    Src="https://www.film.ru/sites/default/files/styles/epsa_260x400/public/movies/posters/4677076-1076094.jpg"
               }
            };
            return View(viewModels);
        }

   
    }
}
