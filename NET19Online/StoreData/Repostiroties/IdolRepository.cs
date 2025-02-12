using StoreData.Models;

namespace StoreData.Repostiroties
{
    public class IdolRepository
    {
        private StoreDbContext _dbContext;

        public IdolRepository(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<IdolData> GetIdols()
        {
            return _dbContext.Idols.ToList();
        }

        public void AddIdol(IdolData idol)
        {
            _dbContext.Idols.Add(idol);
            _dbContext.SaveChanges();
        }

        public void AddIdols(List<IdolData> idols)
        {
            _dbContext.Idols.AddRange(idols);
            _dbContext.SaveChanges();
        }

        public void Remove(int id)
        {
            var idol = _dbContext.Idols.First(x => x.Id == id);
            _dbContext.Idols.Remove(idol);
            _dbContext.SaveChanges();
        }
    }
}
