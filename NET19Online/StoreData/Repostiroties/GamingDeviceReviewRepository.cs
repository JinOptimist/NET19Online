using StoreData.Models;

namespace StoreData.Repostiroties
{
    public class GamingDeviceReviewRepository : BaseRepository<GamingDeviceReviewData>
    {
        public GamingDeviceReviewRepository(StoreDbContext dbContext) : base(dbContext) { }

        public void AddReview(int deviceId, string review)
        {
            var device = _dbContext.GamingDevices.First(x => x.Id == deviceId);
           
            var deviceReview = new GamingDeviceReviewData
            {
                Created = DateTime.Now,
                Review = review,
                GamingDevice = device
            };

            Add(deviceReview);
        }
    }
}
