using WebStoryFroEveryting.Models.CustomValidationAttribute;
using WebStoryFroEveryting.Models.CustomValidationAttributeForUnderwaterHunter;

namespace WebStoryFroEveryting.Models.UnderwaterHuntersWorld
{
    public class CreateUnderwaterHunterModel
    {
        [IsOnlyEnglishSymbol]
        public string NameHunter { get; set; }
        [IsOnlyEnglishSymbol]
        public string Nationality { get; set; }
        /// <summary>
        /// meters
        /// </summary>
        [isDepthNotZero]
        public int MaxHuntingDepth { get; set; }        
        public string Image { get; set; }
        public bool isAuthenticated { get; set; }
    }
}
