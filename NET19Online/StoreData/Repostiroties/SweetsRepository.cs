using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreData.Models;

namespace StoreData.Repostiroties
{
    public class SweetsRepository
    {
        private StoreDbContext _dbContext;
        public SweetsRepository (StoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
       
        public  List <SweetsData> GetSweets() 
        {
            return _dbContext.Sweets.ToList();
        }
        public void AddModel (SweetsData model)
        {
            _dbContext.Sweets.Add(model);
            _dbContext.SaveChanges();
        }
        public void RemoveModel (int id)
        {
            var model = _dbContext.Sweets.First(x=> x.Id == id);
            _dbContext.Sweets.Remove(model);
            _dbContext.SaveChanges();
        }
    }
}
