using Microsoft.EntityFrameworkCore;
using StoreData.CustomQueryModels;
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

        public int AddLike(int id)
        {
            var idol = _dbSet.First(x => x.Id == id);
            idol.LikesCount++;
            _dbContext.SaveChanges();

            return idol.LikesCount;
        }

        public void AddTag(int idolId, string tagText)
        {
            var tag = _dbContext.IdolTags.FirstOrDefault(x => x.Tag == tagText);
            if (tag is null)
            {
                tag = new IdolTagData { Tag = tagText };
            }

            var idol = Get(idolId);
            idol.Tags.Add(tag);
            _dbContext.SaveChanges();
        }

        public PagginatorModel<IdolData> GetAllWithTags(string? tag, int page, int perPage)
        {
            var query = _dbSet
                .Include(x => x.Tags)
                .Where(idol => tag == null || idol.Tags.Any(t => t.Tag == tag));

            return GetPagginatorModel(query, page, perPage);
        }

        public IdolData GetWithCommentsAndTags(int idolId)
        {
            return _dbSet
                .Include(x => x.Comments)
                .Include(x => x.Tags)
                .First(x => x.Id == idolId);
        }

        public override void Remove(IEnumerable<int> ids)
        {
            var commentsToRemove = _dbContext
                .IdolComments
                .Where(x => ids.Contains(x.Idol.Id));
            _dbContext.IdolComments.RemoveRange(commentsToRemove);

            base.Remove(ids);
        }

        public void UpdateName(int id, string newName)
        {
            var idol = _dbSet.First(x => x.Id == id);
            idol.Name = newName;
            _dbContext.SaveChanges();
        }
    }
}
