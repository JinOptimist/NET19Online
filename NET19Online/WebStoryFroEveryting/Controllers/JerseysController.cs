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
            var jerseys = _jerseyRepository.GetData();
            if(jerseys.Count == 0)
            {
                _jerseyGenerator.GenerateData()
                    .Select(jersey => 
                        new JerseyData
                        {
                            AthleteName = jersey.AthleteName,
                            Club = jersey.Club,
                            Img = jersey.Img,
                            Number = jersey.Number
                        })
                    .ToList()
                    .ForEach(_jerseyRepository.AddJersey);
                jerseys = _jerseyRepository.GetData();
            }
            var _viewModels = jerseys.Select(Map).ToList();
            return View(_viewModels);
        }
        public ActionResult Detail(int id)
        {
            var jerseys = _jerseyRepository.GetData();
            if (jerseys.Count == 0)
            {
                _jerseyGenerator.GenerateData()
                    .Select(jersey =>
                        new JerseyData
                        {
                            AthleteName = jersey.AthleteName,
                            Club = jersey.Club,
                            Img = jersey.Img,
                            Number = jersey.Number
                        })
                    .ToList()
                    .ForEach(_jerseyRepository.AddJersey);
                jerseys = _jerseyRepository.GetData();
            }
            var _viewModels = jerseys.Select(Map).ToList();
            JerseyViewModel model = _viewModels.Where(j => j.Id == id).FirstOrDefault();
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
            _jerseyRepository.RemoveJersey(id);
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
            _jerseyRepository.AddJersey(
                    new JerseyData
                    {
                        AthleteName = createJerseyViewModel.AthleteName,
                        Club = createJerseyViewModel.Club,
                        Img = createJerseyViewModel.Img,
                        Number = createJerseyViewModel.Number
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
                Club = jerseyData.Club
            };
        }
    }
}
