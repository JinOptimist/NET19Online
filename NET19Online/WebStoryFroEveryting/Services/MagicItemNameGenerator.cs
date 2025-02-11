namespace WebStoryFroEveryting.Services
{
    public class MagicItemNameGenerator
    {
        private Random _random = new();
        private List<string> Names = new()
        {
            "Health elixir",
            "Magic grimoire",
            "Ring of Fire",
            "Teleport ring",
            "Magic bag",
            "Unlimited Scroll"
        };

        public string GetRandomName()
        {
            var randomNameIndex = _random.Next(Names.Count);
            return Names[randomNameIndex];
        }
    }
}
