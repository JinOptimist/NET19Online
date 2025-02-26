namespace WebStoryFroEveryting.Services
{
    public class SweetsNameGenerator
    {
        private List<string> Names = new()
        {
            "Наполеон",
            "Медовик",
            "Тирамису"
        };
        private Random _random = new();

        public string GetRandomName()
        {
            var randomNameIndex = _random.Next(Names.Count);
            return Names[randomNameIndex];
        }
    }
}
