using StoreData.Repostiroties;
using WebStoryFroEveryting.Models.Films;
using static System.Net.Mime.MediaTypeNames;
using static System.Net.WebRequestMethods;

namespace WebStoryFroEveryting.Services.FilmsServer
{
    public class FilmsGeneratorServices
    {
        private Dictionary<int, List<CreateFilmsViewModel>> _generatorName = new()
        {
            {1, new List<CreateFilmsViewModel>
                {
                     new CreateFilmsViewModel
                     {
                          Name="Аватар ", Src="https://clck.ru/3GQKyT"
                     }
                }
            },
            {2, new List<CreateFilmsViewModel>
                {
                     new CreateFilmsViewModel
                     {
                          Name="Тёмная Материя", Src="https://clck.ru/3GQL2w"
                     }
                }
            },
            {3, new List<CreateFilmsViewModel>
                {
                     new CreateFilmsViewModel
                     {
                          Name="Кунг-Фу Панда 4", Src="https://clck.ru/3GQL56"
                     }
                }
            },
            {4, new List<CreateFilmsViewModel>
                {
                     new CreateFilmsViewModel
                     {
                          Name="Fallou", Src="https://clck.ru/3GQL84"
                     }
                }
            },
        };
        private Random _random = new();

        public FilmsGeneratorServices() { }

        public List<FilmsViewModel> GenerateFilms()
        {
            var ItemsGenerator = new List<FilmsViewModel>(); 
            var randomImagesIndex = Enumerable.Range(1, 4).OrderBy(x => _random.Next()).ToList();
            var _numbers = new Queue<int>(randomImagesIndex);
            for (int i = 0; i < _generatorName.Count; i++)
            {
                var j = _numbers.Dequeue();
                var item = _generatorName[j];
                var films = new FilmsViewModel()
                {
                    Name = item[0].Name,
                    Src =item[0].Src,
                };
                ItemsGenerator.Add(films);
            }

            return ItemsGenerator;
        }
    }
}
