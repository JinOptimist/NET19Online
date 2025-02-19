using StoreData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreData.Repostiroties
{
    public class JerseyCommentRepository: BaseRepository<JerseyCommentData>
    {
        public JerseyCommentRepository(StoreDbContext storeDbContext) : base(storeDbContext) { }

        public void AddComment(int jerseyId, string comment)
        {
            var jersey = _dbContext.Jerseys.First(x => x.Id == jerseyId);
            var commentData = new JerseyCommentData
            {
                Created = DateTime.Now,
                Jersey = jersey,
                Comment = comment
            };
            Add(commentData);
        }
    }
}
