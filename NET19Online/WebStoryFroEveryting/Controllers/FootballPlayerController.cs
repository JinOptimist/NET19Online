using Microsoft.AspNetCore.Mvc;
using WebStoryFroEveryting.Models.FootballTeam;

namespace WebStoryFroEveryting.Controllers
{
    public class FootballPlayerController : Controller
    {
        public IActionResult ViewInfoAboutTeamPlayer()
        {
            var viewModels = new List<PlayerViewModel>
            {
                new()
                {
                    Name = "Андрей Лунев",
                    Src  = "https://fcdynamo.ru/cdn/dynamo/resized_photos/4e4c838e-55d1-43f9-9a29-d536d7c668de/835592_1280x1640.webp",
                    Position = "Вратарь",
                    Weight = 82,
                    Height = 190
                },
                new()
                {
                    Name = "Луис Чавес",
                    Src  = "https://fcdynamo.ru/cdn/dynamo/resized_photos/9622d10d-c851-4d6a-a054-1edf10bb4e4a/834653_1280x1640.webp",
                    Position = "Полузащитник",
                    Weight = 73,
                    Height = 178
                },
                new()
                {
                    Name = "Николя Муми Нгамалё",
                    Src  = "https://fcdynamo.ru/cdn/dynamo/resized_photos/3e0a55bf-cbbe-4e23-90d2-d0d53d77e55e/835650_1280x1640.webp",
                    Position = "Нападающий",
                    Weight = 75,
                    Height = 181
                },
                new()
                {
                    Name = "Константин Тюкавин",
                    Src  = "https://fcdm.ru/cdn/dynamo/resized_photos/965bef96-6c0f-43d1-a7eb-687c814747a8/835659_1280x1640.webp",
                    Position = "Нападающий",
                    Weight = 80,
                    Height = 180
                }
            };

            return View(viewModels);
        }
    }
}
