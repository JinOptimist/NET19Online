using WebStoryFroEveryting.Models.GamingDevice;

namespace WebStoryFroEveryting.Services
{
    public class GamingDeviceGenerator
    {
        private Random _random = new();

        private List<GamingDeviceViewModel> Devices = new()
        {
            new GamingDeviceViewModel
            {
                Name = "Игровая мышь DeathAdder Essential",
                Brand = "Razer",
                Price = 93.42m,
                Src  = "https://img.5element.by/import/images/ut/goods/good_f3262a0f-ff6a-11eb-bb92-0050560120e8/rz01-03850100-r3m1-razer-igrovaya-mysh-deathadder-essential-1_600.jpg"
            },
            new GamingDeviceViewModel
            {
                Name = "Клавиатура Alloy Origins",
                Brand = "HyperX",
                Price = 359.00m,
                Src  = "https://img.5element.by/import/images/ut/goods/good_b4a38539-29f2-11ee-bb94-005056012463/4p4f6aa-aba-hx-kb6rdx-ru-klaviatura-hyperx-alloy-origins-1_600.jpg"
            },
            new GamingDeviceViewModel
            {
                Name = "Гарнитура G332",
                Brand = "LOGITECH",
                Price = 265.00m,
                Src  = "https://img.5element.by/import/images/ut/goods/good_4fb9b46b-9678-11e9-80c7-005056840c70/g332-l981-000757-igrovaya-garnitura-logitech-1_600.jpg"
            },
            new GamingDeviceViewModel
            {
                Name = "Игровой коврик QcK Hard Pad",
                Brand = "STEELSERIES",
                Price = 65.40m,
                Src  = "https://img.5element.by/import/images/ut/goods/good_b4dbdecc-292e-11e9-80c7-005056840c70/good_img_0aa4b720-30ec-11e9-80c7-005056840c70_600.jpg"
            },
            new GamingDeviceViewModel
            {
                Name = "Наушники BlackShark V2 X",
                Brand = "Razer",
                Price = 245.00m,
                Src  = "https://img.5element.by/import/images/ut/goods/good_4f55f6f7-ff6c-11eb-bb92-0050560120e8/rz04-03240100-r3m1-razer-igrovaya-garnitura-blackshark-v2-x-1.jpg"
            },
            new GamingDeviceViewModel
            {
                Name = "Клавиатура механическая RK-S98 Blackberry Chartreuse switch",
                Brand = "Royal Kludge",
                Price = 329.00m,
                Src  = "https://img.5element.by/import/images/ut/goods/good_fef397f5-d1b6-11ef-8db4-005056012b6d/rk-s98-blackberry-klaviatura-mehanicheskaya-chartreuse-switch-royal-kludge-1.jpg"
            },
            new GamingDeviceViewModel
            {
                Name = "Коврик для мышиFlick XL",
                Brand = "Redragon",
                Price = 55.90m,
                Src  = "https://img.5element.by/import/images/ut/goods/good_8f364e00-5445-11ec-bb94-0050560120e8/77990-igrovoy-kovrik-flick-xl-redragon-1.jpg"
            }
        };

        public List<GamingDeviceViewModel> GenerateDevices(int count)
        {
            var list = new List<GamingDeviceViewModel>();

            for (int i = 0; i < count; i++)
            {
                var randomDeviceIndex = _random.Next(Devices.Count);
                list.Add(Devices[randomDeviceIndex]);
            }

            return list;
        }
    }
}
