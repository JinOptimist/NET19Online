using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreData.Models;

namespace StoreData.Repostiroties
{
    public class SweetsCommentsRepository : BaseRepository<SweetsCommentsData>
    {
        public SweetsCommentsRepository(StoreDbContext dbContext) : base(dbContext) { }

        public void AddComment(int sweetsId, string comment)
        {
            var sweets = _dbContext.Sweets.First(x => x.Id == sweetsId);
            var sweetsComment = new SweetsCommentsData
            {
                Created = DateTime.Now,
                Comment = comment,
                Sweets = sweets
            };
            Add(sweetsComment);
        }
    }
}
