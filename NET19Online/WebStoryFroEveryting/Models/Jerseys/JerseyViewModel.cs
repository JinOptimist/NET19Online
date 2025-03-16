namespace WebStoryFroEveryting.Models.Jerseys
{
    public class JerseyViewModel
    {
        public int Id { get; set; }
        public string Club { get; set; }
        public int Number { get; set; }
        public string AthleteName { get; set; }
        public string Img { get; set; }
        public string? SecondImg { get; set; }
        public int InStock { get; set; }
        public decimal Price { get; set; }
    }
}
