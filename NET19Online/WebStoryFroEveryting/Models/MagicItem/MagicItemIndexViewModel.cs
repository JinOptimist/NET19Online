using WebStoryFroEveryting.Models.AnimeGirl;

namespace WebStoryFroEveryting.Models.MagicItem
{
    public class MagicItemIndexViewModel
    {
        public bool CanUserFillters { get; set; }
        public string CurrentTag { get; set; }
        public List<string> Tags { get; set; }
        public List<MagicItemViewModel> MagicItems { get; set; }
    }
}
