using Microsoft.AspNetCore.Mvc;
using WebStoryFroEveryting.Models.AnimeGirl;
using WebStoryFroEveryting.Models.Tanks;
using WebStoryFroEveryting.Services;

namespace WebStoryFroEveryting.Controllers
{
    public class TanksController : Controller
    {

        public IActionResult CreatOrderForTank()
        {

            var generator = new TanksGenerator();

            var viewModels = generator.GenerateTanks(5);

            return View(viewModels);
        }


       
    }
}
