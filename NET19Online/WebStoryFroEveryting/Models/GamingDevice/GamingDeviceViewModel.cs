using System.ComponentModel.DataAnnotations;
using WebStoryFroEveryting.Models.CustomValidationAttribute;

namespace WebStoryFroEveryting.Models.GamingDevice
{
    public class GamingDeviceViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [RangeLength(2, 15)]
        public string Brand { get; set; }

        public decimal Price { get; set; }

        [IsLink]
        public string Src { get; set; }
    }
}
