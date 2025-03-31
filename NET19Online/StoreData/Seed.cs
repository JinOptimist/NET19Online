using Microsoft.Extensions.DependencyInjection;
using StoreData.Repostiroties;

namespace StoreData
{
    public class Seed
    {
        public const string ADMIN_NAME = "admin";
        public void CheckAndFillWithDefaultEntytiesDatabase(IServiceProvider serviceProvider)
        {
            using var di = serviceProvider.CreateScope();

            FillUsers(di.ServiceProvider);
            FillIdols(di.ServiceProvider);
        }

        private void FillIdols(IServiceProvider service)
        {
            var idolRepository = service.GetRequiredService<IdolRepository>();
            if (!idolRepository.Any())
            {
                idolRepository.Add(new Models.IdolData
                {
                    Age = 16,
                    Name = "Night",
                    Src = "https://as1.ftcdn.net/v2/jpg/05/94/50/66/1000_F_594506690_df5uWMrkwIQlfAO4g3jJUcM33C8giVZN.jpg"
                });

                idolRepository.Add(new Models.IdolData
                {
                    Age = 32,
                    Name = "Blue",
                    Src = "https://m.media-amazon.com/images/I/71WbcekHTbL._AC_UF894,1000_QL80_.jpg"
                });

                idolRepository.Add(new Models.IdolData
                {
                    Age = 30,
                    Name = "Azur",
                    Src = "https://rare-gallery.com/uploads/posts/325855-Azur-Lane-Takao-Katana-Anime-Girl-4K-iphone-wallpaper.jpg"
                });

                idolRepository.Add(new Models.IdolData
                {
                    Age = 18,
                    Name = "Full",
                    Src = "https://img10.reactor.cc/pics/post/full/Anime-Original-Anime-Anime-Ero-Anime-Adult-Wet-7105220.jpeg"
                });

                idolRepository.Add(new Models.IdolData
                {
                    Age = 20,
                    Name = "long+hair",
                    Src = "https://oimages.anime-pictures.net/565/5655ec8a7540507d740457a24714ff51.jpg?if=ANIME-PICTURES.NET_-_775334-5334x3000-azur+lane-aegir+%28azur+lane%29-sune+%28mugendai%29-single-long+hair-looking+at+viewer.jpg"
                });
            }
        }

        private void FillUsers(IServiceProvider service)
        {
            var userRepository = service.GetRequiredService<IUserRepository>();
            if (!userRepository.Any(ADMIN_NAME))
            {
                userRepository.Registration(ADMIN_NAME, ADMIN_NAME);
            }
        }
    }
}
