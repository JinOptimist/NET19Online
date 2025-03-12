using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Npgsql.EntityFrameworkCore.PostgreSQL.Query.Internal;
using StoreData.Models;
using StoreData.Repostiroties;
using WebStoryFroEveryting.Hubs;
using WebStoryFroEveryting.Models.AnimeGirl;
using WebStoryFroEveryting.Models.CustomValidationAttribute;

namespace WebStoryFroEveryting.Controllers.ApiControllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class IdolController : ControllerBase
    {
        private IdolRepository _idolRepository;
        private IHubContext<IdolHub, IIdolHub> _idolHub;

        public IdolController(IdolRepository idolRepository, 
            IHubContext<IdolHub, IIdolHub> idolHub)
        {
            _idolRepository = idolRepository;
            _idolHub = idolHub;
        }

        public bool UpdateName(int id, string newName)
        {
            _idolRepository.UpdateName(id, newName);
            return true;
        }

        public void Remove(int id)
        {
            _idolRepository.Remove(id);
        }

        public int Create([FromForm] CreateIdolViewModel viewModel)
        {
            var idol = new IdolData
            {
                Name = viewModel.Name,
                Src = viewModel.Src,
            };
            _idolRepository.Add(idol);

            _idolHub.Clients.All.IdolWasAdded(idol.Src);

            return idol.Id;
        }

        public void Like(int id)
        {
            var likeCount = _idolRepository.AddLike(id);
            // notify 
            _idolHub.Clients.All.LikeUpdated(id, likeCount);
        }

        public IdolViewModel Get(int id)
        {
            var idol = _idolRepository.Get(id);
            var viewModel = new IdolViewModel
            {
                Id = idol.Id,
                Name = idol.Name,
                Src = idol.Src,
            };
            return viewModel;
        }
    }
}
