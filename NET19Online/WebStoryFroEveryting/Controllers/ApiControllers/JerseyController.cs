using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreData.Models;
using StoreData.Repostiroties;
using WebStoryFroEveryting.Controllers.CustomAutorizeAttributes;
using WebStoryFroEveryting.Models.Jerseys;

namespace WebStoryFroEveryting.Controllers.ApiControllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class JerseyController : ControllerBase
    {
        private JerseyRepository _jerseyRepository;
        public JerseyController(JerseyRepository jerseyRepository)
        {
            _jerseyRepository = jerseyRepository;
        }

        public List<JerseyData> GetJerseys()
        {
            return _jerseyRepository.GetAll();
        }

        [IsAdmin]
        public int CreateJersey([FromForm] CreateJerseyViewModel jersey)
        {
            var jerseyData = new JerseyData();
            jerseyData.Price = jersey.Price;
            jerseyData.AthleteName = jersey.AthleteName;
            jerseyData.Number = jersey.Number;
            jerseyData.Img = jersey.Img;
            jerseyData.SecondImg = jersey.SecondImg;
            jerseyData.InStock = jersey.InStock;
            jerseyData.Club = jersey.Club;
            return _jerseyRepository.AddJerseyAndGetId(jerseyData);
        }
    }


}
