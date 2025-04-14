using Azure;
using Microsoft.EntityFrameworkCore;
using StoreData.CustomQueryModels;
using StoreData.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace StoreData.Repostiroties
{
    public abstract class BaseRepository<DbModel> : IBaseRepository<DbModel> where DbModel : BaseModel
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

        public virtual void Remove(IEnumerable<int> ids)
        {
            var items = _dbSet.Where(x => ids.Contains(x.Id));
            _dbSet.RemoveRange(items);
            _dbContext.SaveChanges();
        }

        public virtual bool Any()
        {
            return _dbSet.Any();
        }

        public virtual int Count()
        {
            return _dbSet.Count();
        }

        protected PagginatorModel<DbModel> GetPagginatorModel(
            int page,
            int perPage)
        {
            return GetPagginatorModel(_dbSet, page, perPage);
        }

        protected PagginatorModel<T> GetPagginatorModel<T>(
            IQueryable<T> query,
            int page,
            int perPage)
        {
            var totalCount = query.Count();// 1 000 000

            var items = query
                .Skip((page - 1) * perPage)
                .Take(perPage)
                .ToList(); // 8 data

            var model = new PagginatorModel<T>
            {
                Items = items,
                TotalCount = totalCount,
                Page = page,
                PerPage = perPage
            };

            return model;
        }
    }
}
