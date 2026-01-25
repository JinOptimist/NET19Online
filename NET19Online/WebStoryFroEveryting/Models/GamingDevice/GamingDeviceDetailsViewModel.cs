namespace WebStoryFroEveryting.Models.GamingDevice
{
    public class GamingDeviceDetailsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public decimal Price { get; set; }
        public string Src { get; set; }
        public bool CanUserLeaveReview { get; set; }


        public List<GamingDeviceReviewViewModel> Reviews { get; set; } = new List<GamingDeviceReviewViewModel>();
        public List<GamingDeviceStockAddressesViewModel> StockAddresses { get; set; } = new List<GamingDeviceStockAddressesViewModel>();
    }
}
