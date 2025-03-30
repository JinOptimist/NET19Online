using Enums.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreData.Models;
using StoreData.Repostiroties;
using WebStoryFroEveryting.Controllers.CustomAutorizeAttributes;
using WebStoryFroEveryting.Models.Films;
using WebStoryFroEveryting.Services.FilmsServer;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace WebStoryFroEveryting.Controllers
{
    public class PurchaseFilmsController : Controller
    {
        private FilmsRepository _filmsRepository;
        private FilmsGeneratorServices _filmsGeneratorServices;
        private FilmCommentRepository _filmCommentRepository;
        private IHostingEnvironment _hostingEnvironment;

        public PurchaseFilmsController(FilmsRepository filmsRepository,
            FilmsGeneratorServices filmsGeneratorServices,
            FilmCommentRepository filmCommentRepository, IHostingEnvironment hostingEnvironment)
        {
            _filmsRepository = filmsRepository;
            _filmsGeneratorServices = filmsGeneratorServices;
            _filmCommentRepository = filmCommentRepository;
            _hostingEnvironment = hostingEnvironment;
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
                      Description = "Test",
                      Id = viewModel.id

                  }).ToList()
                  .ForEach(_filmsRepository.Add);
                items = _filmsRepository.GetAll();
            }

            var viewModels = items.Select(Map).ToList();
            return View(viewModels);
        }
        [IsAdmin]
        public IActionResult RemoveFilms(int id)
        {
            _filmsRepository.Remove(id);
            return RedirectToAction(nameof(CreatePurchaseFilms));
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

        public IActionResult DescriptionFilm(int id)
        {
            var descriptionFilmViewModel = new DescriptionFilmViewModel();
            var descriptionFilm = _filmsRepository.GetFilm(id);
            descriptionFilmViewModel.Films.Src = descriptionFilm.Src;
            descriptionFilmViewModel.Films.Name = descriptionFilm.Name;
            descriptionFilmViewModel.DescriptionFilm = descriptionFilm?.DescriptionFilms?.DescriptionFilm;
            descriptionFilmViewModel.Id = descriptionFilm.Id;
            descriptionFilmViewModel.Films.Comments = descriptionFilm.Comments
                .Select(x => new FilmCommentViewModel
                {
                    Id = x.Id,
                    Comment = x.Comment,
                }).ToList();


            return View(descriptionFilmViewModel);
        }


        [HttpPost]
        public IActionResult AddComment(int id, string comment)
        {
            _filmCommentRepository.AddComment(id, comment);
            _filmCommentRepository.RemoveDuplicateComments(id);
            return RedirectToAction(nameof(DescriptionFilm), new { id });
        }
        //ToDo I don't know yet how to change the picture of my movie block
        public IActionResult UpdateImg(IFormFile newimg)
        {
            var fileName = $"img-newImg.jpg";

            var path = Path.Combine(_hostingEnvironment.WebRootPath, "img", fileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                newimg.CopyTo(stream);
            }
                return RedirectToAction(nameof(CreatePurchaseFilms));
        }

        private FilmsViewModel Map(FilmData date)
        {
            return new FilmsViewModel
            {
                Name = date.Name,
                Src = date.Src,
                id = date.Id
            };
        }

    }
}
