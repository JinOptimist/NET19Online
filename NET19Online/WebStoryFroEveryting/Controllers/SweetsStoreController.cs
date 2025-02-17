using Microsoft.AspNetCore.Mvc;
using StoreData;
using StoreData.Models;
using StoreData.Repostiroties;
using WebStoryFroEveryting.Models.SweetsModel;
using WebStoryFroEveryting.Services;


namespace WebStoryFroEveryting.Controllers
{
    public class SweetsStoreController : Controller
    {
        private SweetsModelGenerator _modelGenerator;
        private SweetsRepository _sweetsRepository;
       
        public SweetsStoreController(SweetsModelGenerator modelGenerator, SweetsRepository sweetsRepository)
        {
            _modelGenerator = modelGenerator;
            _sweetsRepository = sweetsRepository;
        }


        public IActionResult CreateOrderForSweets()
        { 
            var sweetsData = _sweetsRepository.GetSweets();
            if (!sweetsData.Any())
            {
                _modelGenerator
                     .GenerateSweetsModel(4)
                     .Select(x =>
                     new SweetsData
                     {
                         Name = x.Name,
                         Src = x.Src
                     })
                     .ToList()
                     .ForEach(_sweetsRepository.AddModel);
                sweetsData = _sweetsRepository.GetSweets();

            }
            var viewModels = sweetsData.Select(Map).ToList();

            return View(viewModels);
        }
        public IActionResult Remove(int id)
        {
            _sweetsRepository.RemoveModel(id);
            return RedirectToAction(nameof(CreateOrderForSweets));

        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        //public IActionResult Create(string name, string src)
        public IActionResult Create(CreateSweetsViewModel viewModel)
        {
            _sweetsRepository.AddModel(
                new SweetsData 
                { Name = viewModel.Name,
                  Src = viewModel.Src 
                });

            return RedirectToAction(nameof(CreateOrderForSweets));
        }
        private SweetsViewModel Map(SweetsData model)
        {
            return new SweetsViewModel

            {
                Id = model.Id,
                Src = model.Src,
                Name = model.Name,
            };
        }

    }

}
