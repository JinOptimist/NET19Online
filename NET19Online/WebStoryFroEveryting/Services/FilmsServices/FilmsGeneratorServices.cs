using StoreData.Repostiroties;
using WebStoryFroEveryting.Models.Films;
using static System.Net.Mime.MediaTypeNames;
using static System.Net.WebRequestMethods;

namespace WebStoryFroEveryting.Services.FilmsServer
{
    public class FilmsGeneratorServices
    {

        private List<CreateFilmsViewModel> _generatorName = new()
        {
            new CreateFilmsViewModel{Name="Аватар", Src="https://clck.ru/3GQKyT"},
            new CreateFilmsViewModel{Name="Кунг-Фу Панда 4", Src="https://clck.ru/3GQL56"},
            new CreateFilmsViewModel{Name="Fallou", Src="https://clck.ru/3GQL84"},
            new CreateFilmsViewModel{Name="Тёмная Материя", Src="https://clck.ru/3GQL2w"},

           new CreateFilmsViewModel{Name="Аватар", Src="https://clck.ru/3GQKyT"},
           new CreateFilmsViewModel{Name="Тёмная Материя", Src="https://clck.ru/3GQL2w"},
           new CreateFilmsViewModel{Name="Кунг-Фу Панда 4", Src="https://clck.ru/3GQL56"},
           new CreateFilmsViewModel{Name="Fallou", Src="https://clck.ru/3GQL84"},
        };

        private Random _random = new();

        public FilmsGeneratorServices() { }

        public List<FilmsViewModel> GenerateFilms()
        {
            var itemsGenerator = new List<FilmsViewModel>();
            var randomImagesIndex = Enumerable.Range(1, 4).OrderBy(x => _random.Next()).ToList();
            var randomImagesIndex = Enumerable.Range(0, 4).OrderBy(x => _random.Next()).ToList();
            var numbers = new Queue<int>(randomImagesIndex);
            for (int i = 0; i < _generatorName.Count; i++)
            {
                var j = numbers.Dequeue();
                var item = _generatorName[j];
                var films = new FilmsViewModel()
                {
                    Name = item.Name,
                    Src = item.Src,
                };
                itemsGenerator.Add(films);
            }
            return itemsGenerator;
        }
    }
}
