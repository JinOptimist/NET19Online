namespace WebStoryFroEveryting.Models.UnderwaterHuntersWorld
{
    public class UnderwaterHunterViewModel
    {
        public int Id { get; set; }
        public string NameHunter { get; set; }
        public string Nationality { get; set; }
        /// <summary>
        /// meters
        /// </summary>
        public int MaxHuntingDepth { get; set; }
        public string Src { get; set; }
        public bool isAuthenticated { get; set; }
        public int LikesCount { get; set; }
        public int DislikesCount { get; set; }
    }
}
