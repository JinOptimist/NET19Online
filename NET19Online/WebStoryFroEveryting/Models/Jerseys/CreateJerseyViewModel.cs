using System.ComponentModel.DataAnnotations;
using WebStoryFroEveryting.Models.CustomValidationAttribute;
namespace WebStoryFroEveryting.Models.Jerseys
{
    public class CreateJerseyViewModel
    {
        [RangeLength(3)]
        public string Club { get; set; }
        [IsPositiveNumber<int>]
        public int Number { get; set; }
        [Required]
        [RangeLength(1)]
        public string AthleteName { get; set; }
        [Required]
        public string Img { get; set; }
        public string SecondImg { get; set; }
        [IsPositiveNumber<int>]
        public int InStock { get; set; }
        [Required]
        [IsPositiveNumber<decimal>]
        public decimal Price { get; set; }
    }
}
