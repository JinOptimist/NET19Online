using StoreData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreData.Repostiroties
{
    public class MagicItemCommentRepository : BaseRepository<MagicItemCommentData>
    {
        public MagicItemCommentRepository(StoreDbContext dbContext) : base(dbContext) { }

        public void AddComment(int magicItemId, string comment)
        {
            var magicItem = _dbContext.MagicItems.First(x => x.Id == magicItemId);

            var magicItemComment = new MagicItemCommentData
            {
                Created = DateTime.Now,
                Comment = comment,
                MagicItem = magicItem
            };

            Add(magicItemComment);
        }
    }
}
