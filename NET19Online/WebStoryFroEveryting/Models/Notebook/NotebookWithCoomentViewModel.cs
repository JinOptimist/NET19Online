namespace WebStoryFroEveryting.Models.Notebook
{
    public class NotebookWithCoomentViewModel
    {
        public int Id { get; set; }
        public string Src { get; set; }
        public string Name { get; set; }

        public List<NotebookCoomentViewModel> Comments { get; set; } = new List<NotebookCoomentViewModel>();
        public List<string> Tags { get; set; } = new List<string>();
    }
}
