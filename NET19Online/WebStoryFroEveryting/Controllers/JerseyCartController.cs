using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebStoryFroEveryting.Models.Jerseys;
using WebStoryFroEveryting.Services.JerseyServices;
using static WebStoryFroEveryting.Models.Jerseys.JerseyCartViewModel;

namespace WebStoryFroEveryting.Controllers
{
    [Route("jerseys/cart/[action]")]
    public class JerseysCartController : Controller
    {
        private JerseyCartViewModel _cart;
        private IHttpContextAccessor _httpContextAccessor;
        private IConfiguration _configuration;

        public JerseysCartController(IHttpContextAccessor httpContextAccessor, IConfiguration configuration)
        {
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
            _cart = _httpContextAccessor.HttpContext.Session.GetObjectFromJson<JerseyCartViewModel>(_configuration["Constants:SessionCartkey"]);
            _configuration = configuration;
        }
        public IActionResult Index()
        {
            return View(_cart);
        }

        [HttpPost]
        public IActionResult AddToCart(JerseyCartItemViewModel item)
        {
            _cart.AddItem(item);
            SaveCartToSession(_cart);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult RemoveFromCart(int id)
        {
            _cart.RemoveItem(id);
            SaveCartToSession(_cart);
            return RedirectToAction("Index");
        }
        private void SaveCartToSession(JerseyCartViewModel cart)
        {
            HttpContext.Session.SetObjectAsJson(_configuration["Constants:SessionCartkey"], cart);
        }
    }
}
