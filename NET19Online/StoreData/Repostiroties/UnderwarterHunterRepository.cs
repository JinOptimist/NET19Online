using Microsoft.EntityFrameworkCore;
using StoreData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreData.Repostiroties
{
    public class UnderwarterHunterRepository : BaseRepository<UnderwaterHunterData>
    {
        public UnderwarterHunterRepository(StoreDbContext dbContext) : base(dbContext) { }

        public UnderwaterHunterData GetHunterWithCommentAndTag(int id)
        {
            var hunter = _dbSet
                 .Include(x => x.Comments)
                 .Include(x => x.Tags)
                 .First(x => x.Id == id);
            return hunter;
        }
        public void AddTag(int id, string tag)
        {
            var tagHunter = _dbContext.UnderwaterHunterTags
                .FirstOrDefault(x => x.Tag == tag);
            if (tagHunter is null)
            {
                tagHunter = new UnderwaterHunterTagData { Tag = tag };
            }

            var hunter = Get(id);
            hunter.Tags.Add(tagHunter);
            _dbContext.SaveChanges();
        }
        public List<UnderwaterHunterData> GetAllHuntersAndTags(string? tag)
        {
            var hunterWithTags = _dbSet
                .Include(x => x.Tags)
                .Where(hunter => tag == null || hunter.Tags.Any(x => x.Tag == tag))
                .ToList();
            return hunterWithTags;
        }
    }
}
