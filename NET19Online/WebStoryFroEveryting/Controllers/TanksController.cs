using Microsoft.AspNetCore.Mvc;
using WebStoryFroEveryting.Services;
using WebStoryFroEveryting.Models.AnimeGirl;
using WebStoryFroEveryting.Models.Tanks;
using StoreData.Models;
using StoreData.Repostiroties;





namespace WebStoryFroEveryting.Controllers
{
    [ApiController]
    public class TanksController : Controller
    {

        private TanksGenerator _tanksGenerator;
        private TanksRepository _tanksRepository;

        public TanksController(TanksGenerator tanksGenerator, TanksRepository tanksRepository)
        {
            _tanksGenerator = tanksGenerator;
            _tanksRepository = tanksRepository;
        }

        public IActionResult CreatOrderForTank()
        {
            var tankDatas = _tanksRepository.GetTank();
            if (!tankDatas.Any())
            {
                _tanksGenerator
                    .GenerateTanks(5)
                    .Select(x =>
                        new TanksData
                        {
                            Name = x.Name,
                            Src = x.Src
                        })
                    .ToList()
                    .ForEach(_tanksRepository.AddTank);
                tankDatas = _tanksRepository.GetTank();
            }

            var viewModels = tankDatas.Select(Map).ToList();
            return View(viewModels);
        }

        public IActionResult Remove(int id)
        {
            _tanksRepository.Remove(id);
            return RedirectToAction(nameof(CreatOrderForTank));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateTankViewModel viewModel)
        //public IActionResult Create(string name, string src)
        {
            _tanksRepository.AddTank(
                new TanksData
                {
                    Name = viewModel.Name,
                    Src = viewModel.Src
                });
            return RedirectToAction(nameof(CreatOrderForTank));
        }



        private TankViewModel Map(TanksData tank)
        {
            return new TankViewModel
            {
                Id = tank.Id,
                Src = tank.Src,
                Name = tank.Name
            };
        }

    }
}
