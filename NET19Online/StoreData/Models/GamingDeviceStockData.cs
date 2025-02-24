namespace StoreData.Models
{
    public class GamingDeviceStockData : BaseModel
    {
        public string Address {  get; set; }

        public virtual List<GamingDeviceData> GamingDevices { get; set; }
    }
}
