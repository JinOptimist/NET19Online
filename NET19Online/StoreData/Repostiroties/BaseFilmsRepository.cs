using Microsoft.EntityFrameworkCore;
using StoreData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreData.Repostiroties
{
    public abstract class BaseFilmsRepository<DbModel> where DbModel : BaseModel
    {
        protected FilmsDbContext _filmsDbContext;
        protected DbSet<DbModel> _filmsSet;
        
        public BaseFilmsRepository(FilmsDbContext filmsDbContext)
        {
           _filmsDbContext = filmsDbContext;
            _filmsSet = _filmsDbContext.Set<DbModel>();
        }

        public virtual List<DbModel> GetAll ()
        {
           return _filmsSet.ToList();
        }

        public virtual DbModel Get(int id)
        {
            return _filmsSet.First(x => x.Id == id);
        }

        public virtual void Add(DbModel film)
        {
            _filmsSet.Add(film);
            _filmsDbContext.SaveChanges();
        }

        public virtual void Remove(DbModel item)
        {
            _filmsSet.Remove(item);
            _filmsDbContext.SaveChanges();
        }
    }
}
