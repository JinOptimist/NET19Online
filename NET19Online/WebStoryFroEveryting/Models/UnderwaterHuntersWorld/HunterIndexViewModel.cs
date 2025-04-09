namespace WebStoryFroEveryting.Models.UnderwaterHuntersWorld
{
    public class HunterIndexViewModel
    {
        public string Author { get; set; }
        public List<string> Tags { get; set; }
        public List<UnderwaterHunterViewModel> Hunters { get; set; }
        public bool isAuthenticated { get; set; }
        public string Quote { get; set; }
    }
}
