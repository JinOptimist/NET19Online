using Microsoft.AspNetCore.Mvc;
using StoreData.Repostiroties;
using StoreData.Models;
using WebStoryFroEveryting.Models.FootballPlayer;
using Microsoft.AspNetCore.Authorization;

namespace WebStoryFroEveryting.Controllers
{
    public class FootballPlayerController : Controller
    {
        private PlayerRepository _playerRepository;
        private PlayerDescriptionRepository _playerDescriptionRepository;

        public FootballPlayerController(PlayerRepository playerRepository, PlayerDescriptionRepository playerDescriptionRepository)
        {
            _playerRepository = playerRepository;
            _playerDescriptionRepository = playerDescriptionRepository;
        }

        public IActionResult Index(string? tag)
        {
            var playerDatas = _playerRepository.GetAllWithTags(tag);

            if (!playerDatas.Any())
            {
                return View(
                    new List<PlayerViewModel>
                    {
                        new()
                        {
                            Name = "Добавьте игрока",
                            Src  = "https://formacenter.ru/wa-data/public/shop/products/26/95/59526/images/134194/134194.970.jpg",
                            Position = "-",
                            Weight = 0,
                            Height = 0
                        }
                    });
            }

            var viewModel = new PlayerIndexViewModel();

            viewModel.Players = playerDatas.Select(
                pd => new PlayerViewModel()
                {
                    Id = pd.Id,
                    Name = pd.Name,
                    Src = pd.Src,
                    Position = pd.Position,
                    Weight = pd.Weight,
                    Height = pd.Height
                }).ToList();

            viewModel.Tags = playerDatas
                .SelectMany(pd => pd.Tags)
                .Select(t => t.Tag)
                .Distinct()
                .ToList();

            viewModel.CurrentTag = tag;

            return View(viewModel);
        }

        [HttpGet]
        [Authorize]
        public IActionResult CreatePlayer()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult CreatePlayer(CreatePlayerViewModel viewModel)
        {
            _playerRepository.Add(
                new PlayerData()
                {
                    Name = viewModel.Name,
                    Src = viewModel.Src,
                    Position = viewModel.Position,
                    Weight = viewModel.Weight,
                    Height = viewModel.Height
                });

            return RedirectToAction(nameof(Index));
        }

        [Authorize]
        public IActionResult RemovePlayer(int id)
        {
            _playerRepository.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult DescriptionForPlayer(int playerId)
        {
            var viewModel = new PlayerWithDescriptionViewModel();
            var player = _playerRepository.GetWithDescriptionsAndTags(playerId);

            viewModel.Id = player.Id;
            viewModel.Src = player.Src;
            viewModel.Descriptions = player.Descriptions.Select(pdd => new PlayerDescriptionViewModel
            {
                Id = pdd.Id,
                Description = pdd.Description
            }).ToList();

            viewModel.Tags = player.Tags.Select(t => t.Tag).ToList();

            return View(viewModel);
        }

        [HttpPost]
        [Authorize]
        public IActionResult AddDescription(int playerId, string description)
        {
            _playerDescriptionRepository.AddDescription(playerId, description);

            return RedirectToAction(nameof(DescriptionForPlayer), new { playerId });
        }

        [HttpPost]
        [Authorize]
        public IActionResult AddTag(int playerId, string tag)
        {
            _playerRepository.AddTag(playerId, tag);

            return RedirectToAction(nameof(DescriptionForPlayer), new { playerId });
        }
    }
}
