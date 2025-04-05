using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebStoryFroEveryting.Controllers
{
    public class PurchaseCartoonController : Controller
    {

        public IActionResult CartoonStore()
        {
            return View();
        }

    }
}
