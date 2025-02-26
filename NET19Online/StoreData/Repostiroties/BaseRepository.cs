using Microsoft.EntityFrameworkCore;
using StoreData.Models;

namespace StoreData.Repostiroties
{
    public abstract class BaseRepository<DbModel> where DbModel : BaseModel
    {
        protected StoreDbContext _dbContext;
        protected DbSet<DbModel> _dbSet;

        public BaseRepository(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<DbModel>();
        }

        public virtual DbModel Get(int id)
        {
            return _dbSet.First(x => x.Id == id);
        }

        public virtual List<DbModel> GetAll()
        {
            return _dbSet.ToList();
        }

        public virtual void Add(DbModel item)
        {
            _dbSet.Add(item);
            _dbContext.SaveChanges();
        }

        public virtual void Remove(int id)
        {
            var item = _dbSet.FirstOrDefault(x => x.Id == id);
            _dbSet.Remove(item);
            _dbContext.SaveChanges();
        }

        public virtual bool Any()
        {
            return _dbSet.Any();
        }
    }
}
