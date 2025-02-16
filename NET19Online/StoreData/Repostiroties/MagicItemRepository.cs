using StoreData.Models;

namespace StoreData.Repostiroties
{
    public class MagicItemRepository : BaseRepository<MagicItemData>
    {
        public MagicItemRepository(StoreDbContext dbContext) : base(dbContext) { }
    }
}
