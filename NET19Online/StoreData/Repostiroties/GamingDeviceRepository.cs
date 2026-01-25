using Microsoft.EntityFrameworkCore;
using StoreData.Models;

namespace StoreData.Repostiroties
{
    public class GamingDeviceRepository : BaseRepository<GamingDeviceData>
    {
        public GamingDeviceRepository(StoreDbContext dbContext) : base(dbContext) { }

        public GamingDeviceData AddDevice(GamingDeviceData newDevice)
        {
            var device = _dbContext.GamingDevices.Add(newDevice);
            _dbContext.SaveChanges();

            return device.Entity;
        }

        public void AddStockToDevice(int deviceId, string stockAddress)
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

        public void RemoveStockFromDevice(int deviceId, int stockAddressId)
        {
            var stock = _dbContext.GamingDeviceStocks
                .FirstOrDefault(x => x.Id == stockAddressId);

            var device = _dbContext.GamingDevices
                .Include(a => a.Stocks)
                .FirstOrDefault(d => d.Id == deviceId);

            device.Stocks.Remove(stock);

            _dbContext.SaveChanges();
        }

        public void UpdateDeviceStock(int deviceId, int stockAddressId, string newStockAddress)
        {
            var stock = _dbContext.GamingDeviceStocks.FirstOrDefault(x => x.Id == stockAddressId);

            var device = Get(deviceId);
            var deviceStock = device.Stocks.FirstOrDefault(stock);
            deviceStock.Address = newStockAddress;
            _dbContext.SaveChanges();
        }

        public List<GamingDeviceData> GetAllWithStock(string? stockAddress)
        {
            return _dbSet
                .Include(x => x.Stocks)
                .Where(device => stockAddress == null || device.Stocks.Any(b => b.Address == stockAddress))
                .ToList();
        }

        public List<GamingDeviceData> GetDevicesByIds(List<int> ids)
        {
            return _dbSet
                .Include(x => x.Stocks)
                .Where(d => ids.Contains(d.Id))
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
