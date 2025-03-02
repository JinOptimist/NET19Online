using System.ComponentModel.DataAnnotations;
using WebStoryFroEveryting.Models.CustomValidationAttribute;

namespace WebStoryFroEveryting.Models.FootballPlayer
{
    public class CreatePlayerViewModel
    {
        [RangeLength(2, 50)]
        public string Name { get; set; }

        [RangeLength(0)]
        public string Src { get; set; }

        [RangeLength(2, 15)]
        public string Position { get; set; }

        [RangeHeightWeight(50, 100)]
        public int Weight { get; set; }

        [RangeHeightWeight(140, 220)]
        public int Height { get; set; }
    }
}
