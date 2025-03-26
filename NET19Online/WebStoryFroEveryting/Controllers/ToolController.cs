using Microsoft.AspNetCore.Mvc;

namespace WebStoryFroEveryting.Controllers
{
    public class ToolController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
