using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebStoryFroEveryting.Models.AnimeGirl
{
    public class IdolIndexViewModel
    {
        public const int PAGGINATOR_MARGIN_SIZE = 2;

        public bool CanUserFillters { get; set; }
        public string CurrentTag { get; set; }
        public List<string> Tags { get; set; }

        public List<IdolViewModel> Idols { get; set; }
        public int TotalCount { get; set; }
        public int PerPage { get; set; }
        public int Page { get; set; }
        public List<int> PagesNumber
        {
            get
            {
                var pageCount = TotalCount % PerPage == 0
                    ? TotalCount / PerPage
                    : TotalCount / PerPage + 1;

                var answer = new List<int> { 1, pageCount };
                answer.AddRange(Enumerable.Range(Page - 2, PAGGINATOR_MARGIN_SIZE * 2 + 1));
                return answer
                    .Where(x => x > 0 && x <= pageCount)
                    .Order()
                    .Distinct()
                    .ToList();
            }
        }

        public List<SelectListItem> PerPageOptions
        {
            get
            {
                var options = new List<int> { 2, 5, 8, 10, 50 };
                return options
                    .Select(x => new SelectListItem
                    {
                        Text = x.ToString(),
                        Value = x.ToString(),
                        Selected = x == PerPage
                    })
                    .ToList();
            }
        }

        public List<UserAndIdolsAgesViewModel> UserAndIdolsAges { get; set; }
    }
}
