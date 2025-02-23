using Npgsql.Internal;
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

        public void AddComment(int id, string comment)
        {
            var hunterId = _dbContext.UnderwaterHunters
                .First(x => x.Id == id);

            var hunterComment = new UnderwaterHunterCommentData
            {
                Comment = comment,
                Create = DateTime.Now,
                HunterId = hunterId
            };
            base.Add(hunterComment);
        }
    }
}
