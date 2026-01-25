namespace WebStoryFroEveryting.Models.GamingDevice
{
    public class GamingDeviceReviewViewModel
    {
        public int Id { get; set; } 
        public string? Review { get; set; }
        public string? AuthorName { get; set; }
        public DateTime Created { get; set; }
    }
}
