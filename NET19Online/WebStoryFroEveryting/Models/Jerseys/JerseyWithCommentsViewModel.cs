using WebStoryFroEveryting.Models.AnimeGirl;

namespace WebStoryFroEveryting.Models.Jerseys
{
    public class JerseyWithCommentsViewModel
    {
        public int Id { get; set; }
        public bool IsTagCreatingEnable { get; set; }
        public bool IsAuthenticated { get; set; }
        public string Club { get; set; }
        public int Number { get; set; }
        public string AthleteName { get; set; }
        public string Img { get; set; }
        public int InStock { get; set; }
        public decimal Price { get; set; }
        public List<JerseyCommentViewModel> Comments { get; set; } = new List<JerseyCommentViewModel>();
        public List<string> Tags { get; set; } = new List<string>();
        public JerseyCartViewModel Cart { get; set; }
    }
}
