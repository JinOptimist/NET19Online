using StoreData.Models;

namespace StoreData.Repostiroties
{
    public class IdolRepository : BaseRepository<IdolData>
    {
        public IdolRepository(StoreDbContext dbContext) : base(dbContext) { }

        public void AddIdols(List<IdolData> idols)
        {
            _dbContext.Idols.AddRange(idols);
            _dbContext.SaveChanges();
        }
    }
}
