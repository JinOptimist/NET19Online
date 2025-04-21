using Microsoft.EntityFrameworkCore;
using StoreData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace StoreData.Repostiroties
{
    public class SingerRepository : BaseRepository<SingerData>
    {
        public SingerRepository(StoreDbContext dbContext) : base(dbContext) { }
        public List<SingerData> GetSingers()
        {
            return _dbSet.ToList();
        }
        public void UpdateSinger(int id, string name, string style)
        {
            var singer = _dbSet.Find(id);
            singer.Pseudonym = name;
            singer.Style = style;
            _dbContext.SaveChanges();
        }
        public override void Remove(int id)
        {
            base.Remove(id);
        }
        public SingerData Get(int id)
        {
            return _dbContext.Singers.FirstOrDefault(i=>i.Id==id);
        }
    }
}