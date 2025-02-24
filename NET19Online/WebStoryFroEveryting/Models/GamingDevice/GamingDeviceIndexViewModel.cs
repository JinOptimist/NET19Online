namespace WebStoryFroEveryting.Models.GamingDevice
{
    public class GamingDeviceIndexViewModel
    {
        public bool CanUserFillters { get; set; }
        public string CurrentStockAddress { get; set; }
        public List<string> StockAdresses { get; set; }
        public List<GamingDeviceViewModel> Devices { get; set; }
    }
}
