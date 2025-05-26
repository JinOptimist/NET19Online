namespace WebStoryFroEveryting.Models.Jerseys
{
    public class JerseyIndexViewModel
    {
        public string CurrentTag { get; set; }
        public List<string> Tags { get; set; }
        public bool IsAdmin { get; set; }
        public List<JerseyViewModel> Jerseys { get; set; }
        public JerseyCartViewModel Cart { get; set; }
    }
}
