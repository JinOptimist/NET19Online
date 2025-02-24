using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StoreData.Models;

namespace StoreData.Repostiroties
{
    public class SweetsRepository : BaseRepository<SweetsData>
    {
        public SweetsRepository(StoreDbContext dbContext) : base(dbContext) { }
        public void AddTag(int sweetsId, string tagText)
        {
            var tag = _dbContext.SweetsTags.FirstOrDefault(x => x.Tag == tagText);
            if (tag is null)
            {
                tag = new SweetsTagData { Tag = tagText };
            }
            var sweets = Get(sweetsId);
            sweets.Tags.Add(tag);
            _dbContext.SaveChanges();
        }
        public SweetsData GetWithCommentsAndTags(int sweetsId)
        {
            return _dbSet
                .Include(x => x.Comments)
                .Include(x => x.Tags)
                .First(x => x.Id == sweetsId);
        }
    }
}
