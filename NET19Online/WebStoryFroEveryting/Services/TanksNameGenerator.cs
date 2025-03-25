namespace WebStoryFroEveryting.Services
{
    public class TanksNameGenerator
    {
        private List<string> Names = new()
        {
            "T-34",
            "ИС-2",
            "Тигр",
            "Пантера"
        };

        public string GetRandomName()
        {
            var random = new Random();
            var randomNameIndex = random.Next(Names.Count);
            return Names[randomNameIndex];
        }
    }
}
