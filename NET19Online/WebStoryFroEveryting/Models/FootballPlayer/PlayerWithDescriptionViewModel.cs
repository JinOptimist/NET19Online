namespace WebStoryFroEveryting.Models.FootballPlayer
{
    public class PlayerWithDescriptionViewModel
    {
        public int Id { get; set; }
        public string Src { get; set; }
        public string Name { get; set; }
        public List<PlayerDescriptionViewModel> Descriptions { get; set; } = new();
        public List<string> Tags { get; set; } = new();
    }
}
