namespace StoreData.Models
{
    public class GamingDeviceData : BaseModel
    {
        public string Name { get; set; }
        public string Brand { get; set; }
        public decimal Price { get; set; }
        public string Src { get; set; }
    }
}
