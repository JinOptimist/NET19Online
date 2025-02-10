namespace WebStoryFroEveryting.Services
{
    public class NameGenerator
    {
        private Random _random = new();
        private List<string> Names = new()
        {
            "Юки",
            "Юми",
            "Кири",
            "Кадзу",
            "На",
        };

        public string GetRandomName()
        {
            var randomNameIndex = _random.Next(Names.Count);
            return Names[randomNameIndex];
        }
    }
}
