namespace WebStoryFroEveryting.Services
{
    public class MagicItemCategoryGenerator
    {
        private Random _random = new();
        private List<string> Names = new()
        {
            "Elixirs",
            "Books",
            "Rings",
            "Equipment",
            "Scrolls"
        };

        public string GetRandomCategory()
        {
            var randomNameIndex = _random.Next(Names.Count);
            return Names[randomNameIndex];
        }
    }
}
