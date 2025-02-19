namespace WebStoryFroEveryting.Models.Jerseys
{
    public class JerseyIndexViewModel
    {
        public string CurrentTag { get; set; }
        public List<string> Tags { get; set; }
        public List<JerseyViewModel> Jerseys { get; set; }
    }
}
