namespace WebStoryFroEveryting.Services
{
    public class NameGenerator : INameGenerator
    {
        //private Random _random = new();
        private List<string> Names = new()
        {
            "Юки",
            "Юми",
            "Кири",
            "Кадзу",
            "На",
        };

        public string GetRandomName(int? seed = null)
        {
            var _random = seed == null ? new Random() : new Random(seed.Value);
            var randomNameIndex = _random.Next(Names.Count);
            return Names[randomNameIndex];
        }
    }
}
