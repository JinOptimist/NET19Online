using WebStoryFroEveryting.Models.Auth;

namespace WebStoryFroEveryting.Models.AnimeGirl
{
    public class IdolIndexViewModel
    {
        public bool CanUserFillters { get; set; }
        public string CurrentTag { get; set; }
        public List<string> Tags { get; set; }
        public List<IdolViewModel> Idols { get; set; }
        public List<UserAndIdolsAgesViewModel> UserAndIdolsAges { get; set; }
    }
}
