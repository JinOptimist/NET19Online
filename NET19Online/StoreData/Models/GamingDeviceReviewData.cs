namespace StoreData.Models
{
    public class GamingDeviceReviewData : BaseModel
    {
        public DateTime Created { get; set; }
        public string Review { get; set; }

        public virtual GamingDeviceData GamingDevice { get; set; }
    }
}
