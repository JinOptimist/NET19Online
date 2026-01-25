using Microsoft.Extensions.DependencyInjection;
using StoreData.Models;
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
            FillDevices(di.ServiceProvider);
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

        private void FillDevices(IServiceProvider service)
        {
            var deviceRepository = service.GetRequiredService<GamingDeviceRepository>();
            if (!deviceRepository.Any())
            {
                deviceRepository.AddGamingDeviceList(new List<GamingDeviceData>
                {
                    new GamingDeviceData
                    {
                        Name = "Игровая мышь DeathAdder Essential",
                        Brand = "Razer",
                        Price = 93.42m,
                        Src  = "https://img.5element.by/import/images/ut/goods/good_f3262a0f-ff6a-11eb-bb92-0050560120e8/rz01-03850100-r3m1-razer-igrovaya-mysh-deathadder-essential-1_600.jpg"
                    },
                    new GamingDeviceData
                    {
                        Name = "Клавиатура Alloy Origins",
                        Brand = "HyperX",
                        Price = 359.00m,
                        Src  = "https://img.5element.by/import/images/ut/goods/good_b4a38539-29f2-11ee-bb94-005056012463/4p4f6aa-aba-hx-kb6rdx-ru-klaviatura-hyperx-alloy-origins-1_600.jpg"
                    },
                    new GamingDeviceData
                    {
                        Name = "Гарнитура G332",
                        Brand = "LOGITECH",
                        Price = 265.00m,
                        Src  = "https://img.5element.by/import/images/ut/goods/good_4fb9b46b-9678-11e9-80c7-005056840c70/g332-l981-000757-igrovaya-garnitura-logitech-1_600.jpg"
                    },
                    new GamingDeviceData
                    {
                        Name = "Игровой коврик QcK Hard Pad",
                        Brand = "STEELSERIES",
                        Price = 65.40m,
                        Src  = "https://img.5element.by/import/images/ut/goods/good_b4dbdecc-292e-11e9-80c7-005056840c70/good_img_0aa4b720-30ec-11e9-80c7-005056840c70_600.jpg"
                    },
                    new GamingDeviceData
                    {
                        Name = "Наушники BlackShark V2 X",
                        Brand = "Razer",
                        Price = 245.00m,
                        Src  = "https://img.5element.by/import/images/ut/goods/good_4f55f6f7-ff6c-11eb-bb92-0050560120e8/rz04-03240100-r3m1-razer-igrovaya-garnitura-blackshark-v2-x-1.jpg"
                    },
                    new GamingDeviceData
                    {
                        Name = "Клавиатура механическая RK-S98 Blackberry Chartreuse switch",
                        Brand = "Royal Kludge",
                        Price = 329.00m,
                        Src  = "https://img.5element.by/import/images/ut/goods/good_fef397f5-d1b6-11ef-8db4-005056012b6d/rk-s98-blackberry-klaviatura-mehanicheskaya-chartreuse-switch-royal-kludge-1.jpg"
                    },
                    new GamingDeviceData
                    {
                        Name = "Коврик для мыши Flick XL",
                        Brand = "Redragon",
                        Price = 55.90m,
                        Src  = "https://img.5element.by/import/images/ut/goods/good_8f364e00-5445-11ec-bb94-0050560120e8/77990-igrovoy-kovrik-flick-xl-redragon-1.jpg"
                    }
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
