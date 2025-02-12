namespace WebStoryFroEveryting.Services
{
    public class NameNotebookGenerator
    {
        private Random _random = new();
        private List<string> Names = new()
        {
            "APPLE MacBook 12",
            "Lenovo IdeaPad 3",
            "Acer NX.ADBER.002"
        };
        public string GetRandomNameNotebook() 
        {
            
            var randomNameIndex = _random.Next(Names.Count);
            return Names[randomNameIndex];
        }

    }
}
