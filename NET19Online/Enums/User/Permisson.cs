using System.ComponentModel.DataAnnotations;

namespace Enums.User
{
    [Flags]
    public enum Permisson
    {
        [Display(Name = "Если ты можешь создать картинку Идола")]
        CanAddIdol = 1,             // => 0000 0001
        [Display(Name = "CanDeleteIdol")]
        CanDeleteIdol = 2,          // => 0000 0010
        [Display(Name = "CanAddIdolComment")]
        CanAddIdolComment = 4,      // => 0000 0100
        [Display(Name = "CanDeleteIdolComment")]
        CanDeleteIdolComment = 8,   // => 0000 1000
        [Display(Name = "CanAddIdolTag")]
        CanAddIdolTag = 16,         // => 0001 0000
        [Display(Name = "CanDeleteIdolTag")]
        CanDeleteIdolTag = 32,      // => 0010 0000
    }
}
