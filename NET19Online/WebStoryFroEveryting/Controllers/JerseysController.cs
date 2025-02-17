using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreData.Models;
using StoreData.Repostiroties;
using WebStoryFroEveryting.Models.Jerseys;
using WebStoryFroEveryting.Services;

namespace WebStoryFroEveryting.Controllers
{
    public class JerseysController : Controller
    {
        private JerseyGenerator _jerseyGenerator;
        private JerseyRepository _jerseyRepository;

        public JerseysController(JerseyGenerator jerseyGenerator, JerseyRepository jerseyRepository)
        {
            _jerseyGenerator = jerseyGenerator;
            _jerseyRepository = jerseyRepository;
        }
        public ActionResult Index()
        {
            var jerseys = _jerseyRepository.GetAll();
            if(!jerseys.Any())
            {
                _jerseyGenerator.GenerateData()
                    .Select(jersey => 
                        new JerseyData
                        {
                            AthleteName = jersey.AthleteName,
                            Club = jersey.Club,
                            Img = jersey.Img,
                            Number = jersey.Number,
                            InStock = jersey.InStock,
                            Price = jersey.Price
                        })
                    .ToList()
                    .ForEach(_jerseyRepository.Add);
                jerseys = _jerseyRepository.GetAll();
            }
            var viewModels = jerseys.Select(Map).ToList();
            return View(viewModels);
        }
        public ActionResult Detail(int id)
        {
            var jerseys = _jerseyRepository.GetAll();
            if (!jerseys.Any())
            {
                _jerseyGenerator.GenerateData()
                    .Select(jersey =>
                        new JerseyData
                        {
                            AthleteName = jersey.AthleteName,
                            Club = jersey.Club,
                            Img = jersey.Img,
                            Number = jersey.Number,
                            InStock = jersey.InStock,
                            Price = jersey.Price
                        })
                    .ToList()
                    .ForEach(_jerseyRepository.Add);
                jerseys = _jerseyRepository.GetAll();
            }
            var viewModels = jerseys.Select(Map).ToList();
            var model = viewModels.Where(j => j.Id == id).FirstOrDefault();
            if (model == null)
            {
                Response.StatusCode = 404;
                return View("JerseysError");
            }
            
            return View(model);
        }
        [HttpGet]
        public ActionResult Remove(int id)
        {
            _jerseyRepository.Remove(id);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateJerseyViewModel createJerseyViewModel)
        {
            _jerseyRepository.Add(
                    new JerseyData
                    {
                        AthleteName = createJerseyViewModel.AthleteName,
                        Club = createJerseyViewModel.Club,
                        Img = createJerseyViewModel.Img,
                        Number = createJerseyViewModel.Number,
                        InStock = createJerseyViewModel.InStock,
                        Price = createJerseyViewModel.Price
                    });
            return RedirectToAction(nameof(Index));
        }
        private JerseyViewModel Map(JerseyData jerseyData)
        {
            return new JerseyViewModel
            {
                Id = jerseyData.Id,
                Number = jerseyData.Number,
                AthleteName = jerseyData.AthleteName,
                Img = jerseyData.Img,
                Club = jerseyData.Club,
                InStock = jerseyData.InStock,
                Price = jerseyData.Price
            };
        }
    }
}
