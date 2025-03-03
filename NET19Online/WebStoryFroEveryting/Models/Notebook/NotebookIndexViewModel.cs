namespace WebStoryFroEveryting.Models.Notebook
{
    public class NotebookIndexViewModel
    {
        public bool CanUserFillters { get; set; }
        public string CurrentTag { get; set; }
        public List<string> Tags { get; set; }
        public List<NotebookViewModel> Notebooks { get; set; }
    }
}
