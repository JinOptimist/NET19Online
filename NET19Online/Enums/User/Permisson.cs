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
        [Display(Name = "CanCreatHunter")]
        CanCreatHunter = 64,
        [Display(Name = "CanDeleteHunterComment")]
        CanDeleteHunterComment = 128,
        [Display(Name = "CanDeleteHunterTag")]
        CanDeleteHunterTag = 256,
        [Display(Name = "CanDeleteHunter")]
        CanDeleteHunter = 512,
        [Display(Name = "CanAddPlayer")]
        CanAddPlayer = 134_217_728,
        [Display(Name = "CanDeletePlayer")]
        CanDeletePlayer = 268_435_456,
        [Display(Name = "CanAddPlayerDescriptions")]
        CanAddPlayerDescription = 536_870_912,
        [Display(Name = "CanAddPlayerTag")]
        CanAddPlayerTag = 1_073_741_824,
        [Display(Name = "CanCreateJersey")]
        CanCreateJersey = 1024,
        [Display(Name = "CanRemoveJersey")]
        CanRemoveJersey = 2048,
        [Display(Name = "CanCreateJerseyTag")]
        CanCreateJerseyTag = 4096,
        [Display(Name = "CanAddGamingDevice")]
        CanAddGamingDevice = 8192,
        [Display(Name = "CanDeleteGamingDevice")]
        CanDeleteGamingDevice = 16384,
        [Display(Name = "CanAddGamingDeviceReview")]
        CanAddGamingDeviceReview = 8192,
        [Display(Name = "CanDeleteGamingDeviceReview")]
        CanDeleteGamingDeviceReview = 32768,
        [Display(Name = "CanAddGamingDeviceStock")]
        CanAddGamingDeviceStock = 65536,
        [Display(Name = "CanDeleteGamingDeviceStock")]
        CanDeleteGamingDeviceStock = 131072,
    }
}
