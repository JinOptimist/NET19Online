using Microsoft.EntityFrameworkCore;
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

        public void AddComment(int jerseyId, string comment, int userId)
        {
            var jersey = _dbContext.Jerseys.First(x => x.Id == jerseyId);
            var user = _dbContext.Users.First(x => x.Id == userId);
            var commentData = new JerseyCommentData
            {
                Created = DateTime.Now,
                Jersey = jersey,
                Comment = comment,
                Author = user
            };
            Add(commentData);
        }
        public void DeleteCommentDuplicates()
        {
            var sql = @"Delete From JerseysComments
Where Id Not In
(
Select Min(Id)
From JerseysComments
Group By Comment, AuthorId
)";
            _dbContext.Database.ExecuteSqlRaw(sql);
        }
    }
}
