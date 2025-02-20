using StoreData.Models;

namespace WebStoryFroEveryting.Models.UnderwaterHuntersWorld
{
    public class CommentHunterViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Src { get; set; }
        public List<UnderwaterHunterCommentViewModel> Comments { get; set; }
        public List<string>? Tags { get; set; }

    }
}
