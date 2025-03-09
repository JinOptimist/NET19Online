using System.ComponentModel.DataAnnotations;
using WebStoryFroEveryting.Models.CustomValidationAttribute;

namespace WebStoryFroEveryting.Models.AnimeGirl
{
    public class CreateIdolViewModel
    {
        [Required]
        [RangeLength(2, 60, ErrorMessage = "Я не верю в имена короче 2 символов. И больше 60 тоже не бывает")]
        public string Name { get; set; }

        [RangeLength(4)]
        public string Src { get; set; }
    }
}
