namespace WebStoryFroEveryting.Models.AnimeGirl
{
    public class IdolWithCommentViewModel
    {
        public int Id { get; set; }
        public string Src { get; set; }
        public string Name { get; set; }

        public List<IdolCommentViewModel> Comments { get; set; } = new List<IdolCommentViewModel>();
        public List<string> Tags { get; set; } = new List<string>();

    }
}
