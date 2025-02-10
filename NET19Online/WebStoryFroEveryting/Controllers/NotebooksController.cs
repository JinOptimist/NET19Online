using Microsoft.AspNetCore.Mvc;
using WebStoryFroEveryting.Models.Notebook;

namespace WebStoryFroEveryting.Controllers
{
    public class NotebooksController : Controller
    {
        public IActionResult CreateOrderForNotebooks()
        {
            var viewModels = new List<notebookViewModel>
            {
                new notebookViewModel
                {
                    Name = "APPLE MacBook 12",
                    Src = "https://static.onlinetrade.ru/img/items/b/apple_noutbuk_macbook_12_i5_dual_1.3_8gb_512gb_ssd_hdg_615_mnyg2ru_a_space_gray_6.jpg"
                },
                new notebookViewModel
                {
                    Name = "Lenovo IdeaPad 3",
                    Src = "https://www.notik.ru/img/catalog/91231/1_lenovoideapad3-1581we01eqrk.jpg"
                },
                new notebookViewModel
                {
                    Name = "Acer NX.ADBER.002",
                    Src = "https://digitik.ru/upload/iblock/679/679209ecba279b9b960d4283a47087b4.jpg"
                },
            };
            return View(viewModels);
        }
    }
}
