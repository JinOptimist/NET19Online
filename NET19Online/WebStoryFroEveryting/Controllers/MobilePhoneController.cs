using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebStoryTest.Controllers
{
    public class MobilePhoneController : Controller
    {
        public IActionResult CreateOrderMobilePhone()
        {
            return View();
        }
    }
}
