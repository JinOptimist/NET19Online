using Enums.User;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebStoryFroEveryting.Models.Home
{
    public class ProfileViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public UserLocale UserLocale { get; set; }

        public List<SelectListItem> AllLocales { get; set; }
    }
}
