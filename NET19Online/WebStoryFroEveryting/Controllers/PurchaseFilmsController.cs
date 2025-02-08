using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebStoryFroEveryting.Controllers
{
    public class PurchaseFilmsController : Controller
    {
        public IActionResult CreatePurchaseFilms()
        {
            return View();
        }

   
    }
}
