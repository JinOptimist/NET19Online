using StoreData.Models;

namespace StoreData.Repostiroties
{
    public class IdolCommentRepository : BaseRepository<IdolCommentData>
    {
        public IdolCommentRepository(StoreDbContext dbContext) : base(dbContext) { }

        public void AddComment(int idolId, string comment, int authorId)
        {
            var idol = _dbContext.Idols.First(x => x.Id == idolId);
            var user = _dbContext.Users.First(x => x.Id == authorId);
           
            var idolComment = new IdolCommentData
            {
                Created = DateTime.Now,
                Comment = comment,
                Idol = idol,
                Author = user
            };

            Add(idolComment);
        }
    }
}
