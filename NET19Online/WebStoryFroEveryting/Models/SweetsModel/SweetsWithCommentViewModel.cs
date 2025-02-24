using System.Xml.Linq;

namespace WebStoryFroEveryting.Models.SweetsModel
{
    public class SweetsWithCommentViewModel
    {
        public int Id { get; set; }
        public string Src { get; set; }
        public string Name { get; set; }
        public List<SweetsCommentViewModel> Comments { get; set; } = new List<SweetsCommentViewModel>();
        public List<string> Tags { get; set; } = new List<string>();
    }
}
