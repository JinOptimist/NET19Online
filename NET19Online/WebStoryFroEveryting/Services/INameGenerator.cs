namespace WebStoryFroEveryting.Services
{
    public interface INameGenerator
    {
        string GetRandomName(int? seed = null);
    }
}