using WebStoryFroEveryting.Models.Films;

namespace WebStoryFroEveryting.Services.FilmsServices.Interface
{
    public interface IFilmsGeneratorServices
    {
        List<string> FilmsName { get; }

        bool NameGenerator(List<string> filmName);
    }
}
