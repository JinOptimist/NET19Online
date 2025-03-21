using Microsoft.AspNetCore.Mvc;
using WebStoryFroEveryting.Models.Tanks;

namespace WebStoryFroEveryting.Controllers
{
    public class TanksController : Controller
    {

        public IActionResult CreatOrderForTank()
        {
            var viewModel = new List<TankViewModel>()
            {
                new TankViewModel
                {
                    Name = "T-34",
                    Src = "https://stalin-line.by/images/exposition/Tank_T34/uztm.jpg"
                },
                new TankViewModel
                {
                    Name = "ИС-2",
                    Src = "https://parkpatriot.ru/upload/iblock/86b/0A7A5187.JPG"
                },
                new TankViewModel
                {
                    Name = "Тигр",
                    Src = "https://tanksdb.ru/images/tanks/tiger.jpg"
                },
                new TankViewModel
                {
                    Name = "Пантера",
                    Src = "https://parkpatriot.ru/upload/iblock/30c/Pantera-vo-aremya-rekonstruktsii.jpg"
                }
            };


            return View(viewModel);
        }
    }
