using WebStoryFroEveryting.Models.CustomValidationAttribute;

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
        public int MaxHuntingDepth { get; set; }
        public string Image { get; set; }
        public bool isAuthenticated { get; set; }
    }
}
