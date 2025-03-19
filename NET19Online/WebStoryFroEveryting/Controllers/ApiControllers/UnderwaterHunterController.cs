using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using StoreData.Models;
using StoreData.Repostiroties;
using WebStoryFroEveryting.Hubs;
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
        private IHubContext<HunterHub, IHunterHub> _hunterHub;
        public UnderwaterHunterController(UnderwarterHunterRepository underwarterHunterRepository,
                                           IHubContext<HunterHub, IHunterHub> hunterHub)
        {
            _underwarterHunterRepository = underwarterHunterRepository;
            _hunterHub = hunterHub;
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
        public void Like(int id)
        {
            var likesCount = _underwarterHunterRepository.Like(id);
            _hunterHub
                .Clients
                .All
                .Like(id, likesCount);
        }
        public void Dislike(int id)
        {
            var dislikesCount = _underwarterHunterRepository.Dislike(id);
            _hunterHub
                .Clients
                .All
                .Dislike(id, dislikesCount);
        }
    }
}
