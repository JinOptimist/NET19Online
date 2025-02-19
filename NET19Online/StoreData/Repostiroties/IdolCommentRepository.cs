using StoreData.Models;

namespace StoreData.Repostiroties
{
    public class IdolCommentRepository : BaseRepository<IdolCommentData>
    {
        public IdolCommentRepository(StoreDbContext dbContext) : base(dbContext) { }

        public void AddComment(int idolId, string comment)
        {
            var idol = _dbContext.Idols.First(x => x.Id == idolId);
           
            var idolComment = new IdolCommentData
            {
                Created = DateTime.Now,
                Comment = comment,
                Idol = idol
            };

            Add(idolComment);
        }
    }
}
