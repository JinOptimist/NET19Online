using Microsoft.AspNetCore.Mvc;
using StoreData.Models;
using StoreData.Repostiroties;
using WebStoryFroEveryting.Models.AnimeGirl;
using WebStoryFroEveryting.Services;

namespace WebStoryFroEveryting.Controllers
{
    public class AnimeGirlController : Controller
    {
        private IdolGenerator _idolGenerator;
        private IdolRepository _idolRepository;

        public AnimeGirlController(IdolGenerator idolGenerator, IdolRepository idolRepository)
        {
            _idolGenerator = idolGenerator;
            _idolRepository = idolRepository;
        }

        public IActionResult CreateOrderForAnimeGirl()
        {
            var idolDatas = _idolRepository.GetAll();
            if (!idolDatas.Any())
            {
                _idolGenerator
                    .GenerateIdols(5)
                    .Select(viewModel =>
                        new IdolData
                        {
                            Name = viewModel.Name,
                            Src = viewModel.Src
                        })
                    .ToList()
                    .ForEach(_idolRepository.Add);
                idolDatas = _idolRepository.GetAll();
            }

            var viewModels = idolDatas.Select(Map).ToList();
            return View(viewModels);
        }

        public IActionResult Remove(int id)
        {
            _idolRepository.Remove(id);
            return RedirectToAction(nameof(CreateOrderForAnimeGirl));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateIdolViewModel viewModel)
        {
            _idolRepository.Add(
                new IdolData
                {
                    Name = viewModel.Name,
                    Src = viewModel.Src
                });
            return RedirectToAction(nameof(CreateOrderForAnimeGirl));
        }

        private IdolViewModel Map(IdolData idol)
        {
            return new IdolViewModel
            {
                Id = idol.Id,
                Src = idol.Src,
                Name = idol.Name,
            };
        }
    }
}
