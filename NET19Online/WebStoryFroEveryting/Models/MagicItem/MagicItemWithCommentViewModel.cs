namespace WebStoryFroEveryting.Models.MagicItem
{
    public class MagicItemWithCommentViewModel
    {
        public int Id { get; set; }
        public string Src { get; set; }
        public string Name { get; set; }

        public List<MagicItemCommentViewModel> Comments { get; set; } = new List<MagicItemCommentViewModel>();
        public List<string> Tags { get; set; } = new List<string>();
    }
}
