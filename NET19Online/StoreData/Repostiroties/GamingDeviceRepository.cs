using StoreData.Models;

namespace StoreData.Repostiroties
{
    public class GamingDeviceRepository : BaseRepository<GamingDeviceData>
    {
        public GamingDeviceRepository(StoreDbContext dbContext) : base(dbContext) { }

        public void AddDevices(List<GamingDeviceData> devices)
        {
            _dbContext.GamingDevices.AddRange(devices);
            _dbContext.SaveChanges();
        }
    }
}
