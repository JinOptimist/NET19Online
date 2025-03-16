using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Npgsql.EntityFrameworkCore.PostgreSQL.Query.Internal;
using StoreData.Models;
using StoreData.Repostiroties;
using WebStoryFroEveryting.Hubs;
using WebStoryFroEveryting.Models.AnimeGirl;
using WebStoryFroEveryting.Models.CustomValidationAttribute;
using WebStoryFroEveryting.Models.FootballPlayer;

namespace WebStoryFroEveryting.Controllers.ApiControllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private PlayerRepository _playerRepository;

        public PlayerController(PlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public bool UpdateName(int id, string newName)
        {
            _playerRepository.UpdateName(id, newName);
            return true;
        }

        public void Remove(int id)
        {
            _playerRepository.Remove(id);
        }

        public int Create([FromForm] CreatePlayerViewModel viewModel)
        {
            var player = new PlayerData
            {
                Name = viewModel.Name,
                Src = viewModel.Src,
                Position = viewModel.Position,
                Weight = viewModel.Weight,
                Height = viewModel.Height
            };

            _playerRepository.Add(player);

            return player.Id;
        }
    }
}
