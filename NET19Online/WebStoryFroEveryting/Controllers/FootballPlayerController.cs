using Microsoft.AspNetCore.Mvc;
using StoreData.Repostiroties;
using StoreData.Models;
using WebStoryFroEveryting.Models.FootballPlayer;

namespace WebStoryFroEveryting.Controllers
{
    public class FootballPlayerController : Controller
    {
        private PlayerRepository _playerRepository;

        public FootballPlayerController(PlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public IActionResult ViewInfoAboutTeamPlayer()
        {
            var playerDatas = _playerRepository.GetPlayers();

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

            var viewModels = playerDatas.Select(
                pd => new PlayerViewModel()
                {
                    Id = pd.Id,
                    Name = pd.Name,
                    Src = pd.Src,
                    Position = pd.Position,
                    Weight = pd.Weight,
                    Height = pd.Height
                }).ToList();

            return View(viewModels);
        }

        [HttpGet]
        public IActionResult CreatePlayer()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreatePlayer(CreatePlayerViewModel viewModel)
        {
            _playerRepository.AddPlayer(
                new PlayerData()
                {
                    Name = viewModel.Name,
                    Src = viewModel.Src,
                    Position = viewModel.Position,
                    Weight = viewModel.Weight,
                    Height = viewModel.Height
                });

            return RedirectToAction(nameof(ViewInfoAboutTeamPlayer));
        }
    }
}
