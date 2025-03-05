using Microsoft.EntityFrameworkCore;
using Npgsql.Internal;
using StoreData.CustomQueryModels;
using StoreData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreData.Repostiroties
{
    public class UnderwarterHunterCommentRepository : BaseRepository<UnderwaterHunterCommentData>
    {
        public UnderwarterHunterCommentRepository(StoreDbContext dbContext) : base(dbContext) { }

        public void AddComment(int id, string comment, int author)
        {
            var hunterId = _dbContext.UnderwaterHunters
                .First(x => x.Id == id);
            var authorId = _dbContext.Users
                .First(x => x.Id == author);
            var hunterComment = new UnderwaterHunterCommentData
            {
                Comment = comment,
                Create = DateTime.Now,
                Hunter = hunterId,
                Author = authorId
            };
            base.Add(hunterComment);
        }

        public List<HunterWithoutDuplicateComments> ShowCommentsWithoutDuplicates()
        {
            var sql = @"select
                               Uh_Comment.Comment Comment                               
                              ,Users.UserName UserName
                              ,Max(Uh_Comment.Id) Id                              
                            from UnderwaterHunterComments Uh_Comment
                            left join UnderwaterHunters UH_Name on Uh_Comment.HunterId=UH_Name.Id 
                            left join Users on Uh_Comment.AuthorId=Users.Id
                            group by Uh_Comment.Comment, UH_Name.NameHunter,Users.UserName";

            return
                _dbContext
                .Database
                .SqlQueryRaw<HunterWithoutDuplicateComments>(sql)
                .ToList();
        }
    }
}
