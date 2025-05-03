using Microsoft.EntityFrameworkCore;
using StoreData.Models;

namespace StoreData.Repostiroties
{
    public class GamingDeviceRepository : BaseRepository<GamingDeviceData>
    {
        public GamingDeviceRepository(StoreDbContext dbContext) : base(dbContext) { }

        public void AddStock(int deviceId, string stockAddress)
        {
            var stock = _dbContext.GamingDeviceStocks.FirstOrDefault(x => x.Address == stockAddress);
            if (stock is null)
            {
                stock = new GamingDeviceStockData { Address = stockAddress };
            }

            var device = Get(deviceId);
            device.Stocks.Add(stock);
            _dbContext.SaveChanges();
        }

        public List<GamingDeviceData> GetAllWithStock()
        {
            return _dbSet
                .Include(x => x.Stocks)
                .ToList();
        }

        public GamingDeviceData GetWithReviewsAndStocks(int deviceId)
        {
            return _dbSet
                .Include(x => x.Reviews)
                .Include(x => x.Stocks)
                .FirstOrDefault(x => x.Id == deviceId);
        }

        public void AddGamingDeviceList(List<GamingDeviceData> gamingDevices)
        {
            _dbSet.AddRange(gamingDevices);
            _dbContext.SaveChanges();
        }

    }
}
