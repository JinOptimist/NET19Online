using Microsoft.EntityFrameworkCore;
using StoreData.Models;

namespace StoreData.Repostiroties
{
    public class MagicItemRepository : BaseRepository<MagicItemData>
    {
        public MagicItemRepository(StoreDbContext dbContext) : base(dbContext) { }

        public void AddTag(int magicItemId, string tagText)
        {
            var tag = _dbContext.MagicItemTags.FirstOrDefault(x => x.Tag == tagText);
            if (tag is null)
            {
                tag = new MagicItemTagData { Tag = tagText };
            }

            var magicItem = Get(magicItemId);
            magicItem.Tags.Add(tag);
            _dbContext.SaveChanges();
        }

        public List<MagicItemData> GetAllWithTags(string? tag)
        {
            return _dbSet
                .Include(x => x.Tags)
                .Where(magicItem => tag == null || magicItem.Tags.Any(t => t.Tag == tag))
                .ToList();
        }

        public MagicItemData GetWithCommentsAndTags(int magicItemId)
        {
            return _dbSet
                .Include(x => x.Comments)
                .Include(x => x.Tags)
                .First(x => x.Id == magicItemId);
        }
    }
}
