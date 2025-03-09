namespace StoreData.Models
{
    public class GamingDeviceData : BaseModel
    {
        public string Name { get; set; }
        public string Brand { get; set; }
        public decimal Price { get; set; }
        public string Src { get; set; }

        public virtual List<GamingDeviceReviewData> Reviews { get; set; }
        public virtual List<GamingDeviceStockData> Stocks { get; set; } = new List<GamingDeviceStockData>();
    }
}
