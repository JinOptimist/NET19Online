namespace WebStoryFroEveryting.Models.UnderwaterHuntersWorld
{
    public class CreateUnderwaterHunterModel
    {             
        public string NameHunter { get; set; }
        public string Nationality { get; set; }
        /// <summary>
        /// meters
        /// </summary>
        public int MaxHuntingDepth { get; set; }
        public string Image { get; set; }
    }
}
