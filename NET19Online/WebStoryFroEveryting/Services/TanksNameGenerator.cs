namespace WebStoryFroEveryting.Services
{
    public class TanksNameGenerator
    {
        private Random _random = new Random();
        private List<string> Names = new()
        {
            "T-34",
            "ИС-2",
            "Тигр",
            "Пантера"
        };

        public string GetRandomName()
        {
            
            var randomNameIndex = _random.Next(Names.Count);
            return Names[randomNameIndex];
        }
    }
}
