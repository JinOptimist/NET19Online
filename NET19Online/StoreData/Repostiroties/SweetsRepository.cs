using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreData.Models;

namespace StoreData.Repostiroties
{
    public class SweetsRepository : BaseRepository<SweetsData>
    {
        public SweetsRepository(StoreDbContext dbContext) : base(dbContext) { }


    }
}
