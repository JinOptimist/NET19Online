using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using StoreData.Repostiroties;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using WebStoryFroEveryting.Models.Films;
using WebStoryFroEveryting.Services.FilmsServices.Interface;
using static System.Net.Mime.MediaTypeNames;
using static System.Net.WebRequestMethods;

namespace WebStoryFroEveryting.Services.FilmsServer
{

    public class FilmsGeneratorServices  : IFilmsGeneratorServices
    {
        private IFilmsGeneratorServices _nameObject;

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

        public List<string> FilmsName => throw new NotImplementedException();

        public FilmsGeneratorServices() { }

        public FilmsGeneratorServices(IFilmsGeneratorServices nameObject)
        {
            _nameObject = nameObject;
        }

        public bool NameGenerator(List<string> filmName)
        {
            if (filmName.Count==1)
            {
                throw new ArgumentException("film Name is empty");
            }

            var isEqual = _nameObject.FilmsName.SequenceEqual(filmName);

            if (isEqual)
            {
                return true;
            }
            return false;
        }

        public List<FilmsViewModel> GenerateFilms()
        {
            var itemsGenerator = new List<FilmsViewModel>();
            var randomImagesIndex = Enumerable.Range(1, 4).OrderBy(x => _random.Next()).ToList();
            var numbers = new Queue<int>(randomImagesIndex);
            for (int i = 0; i < _generatorName.Count; i++)
            {
                var item = _generatorName[i];
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
