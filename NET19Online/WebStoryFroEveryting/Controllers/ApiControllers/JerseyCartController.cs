using Microsoft.AspNetCore.Mvc;
using StoreData.Repostiroties;
using WebStoryFroEveryting.Models.Jerseys;
using WebStoryFroEveryting.Services.JerseyServices;

namespace WebStoryFroEveryting.Controllers.ApiControllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class JerseyCartController : ControllerBase
    {
        private JerseyCartViewModel _cart;
        private IHttpContextAccessor _httpContextAccessor;
        private JerseyRepository _jerseyRepository;
        private IConfiguration _configuration;
        public JerseyCartController(IHttpContextAccessor httpContextAccessor, JerseyRepository jerseyRepository, IConfiguration configuration)
        {
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
            _cart = _httpContextAccessor.HttpContext.Session.GetObjectFromJson<JerseyCartViewModel>(_configuration["Constants:SessionCartkey"]);
            _jerseyRepository = jerseyRepository;
        }

        [HttpPost]
        public JerseyCartViewModel AddToCart([FromBody] int id)
        {
            var jersey = _jerseyRepository.Get(id);
            var cartItem = new JerseyCartItemViewModel
            {
                Id = jersey.Id,
                Image = jersey.Img,
                Name = jersey.AthleteName,
                Price = jersey.Price,
                Quantity = 1
            };

            _cart.AddItem(cartItem);
            SaveCartToSession(_cart);
            return _cart;
        }

        [HttpPost]
        public JerseyCartViewModel RemoveFromCart(int id)
        {
            _cart.RemoveItem(id);
            SaveCartToSession(_cart);
            return _cart;
        }
        private void SaveCartToSession(JerseyCartViewModel cart)
        {
            HttpContext.Session.SetObjectAsJson(_configuration["Constants:SessionCartkey"], cart);
        }
    }
}
