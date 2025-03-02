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
            }
        }

        private void FillUsers(IServiceProvider service)
        {
            var userRepository = service.GetRequiredService<UserRepository>();
            if (!userRepository.Any(ADMIN_NAME))
            {
                userRepository.Registration(ADMIN_NAME, ADMIN_NAME);
            }
        }
    }
}
