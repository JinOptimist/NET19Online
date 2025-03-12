using Microsoft.AspNetCore.Mvc;
using StoreData.Models;
using StoreData.Repostiroties;
using WebStoryFroEveryting.Models.AnimeGirl;
using WebStoryFroEveryting.Models.CustomValidationAttribute;
using WebStoryFroEveryting.Models.UnderwaterHuntersWorld;
using WebStoryFroEveryting.Services;
using static System.Net.Mime.MediaTypeNames;

namespace WebStoryFroEveryting.Controllers.ApiControllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UnderwaterHunterController : ControllerBase
    {
        private UnderwarterHunterRepository _underwarterHunterRepository;

        public UnderwaterHunterController(UnderwarterHunterRepository underwarterHunterRepository)
        {
            _underwarterHunterRepository = underwarterHunterRepository;
        }

        public void Remove(int id)
        {
            _underwarterHunterRepository.Remove(id);
        }


        public int Create(string name, string nationality, int maxDepth, string image)
        {            
            var newHunter = new UnderwaterHunterData
            {
                NameHunter = name,
                Nationality = nationality,
                MaxHuntingDepth = maxDepth,
                Src = image,              
            };
            _underwarterHunterRepository.Add(newHunter);
            return newHunter.Id;         
        }
    }
}
