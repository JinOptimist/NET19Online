using StoreData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreData.Repostiroties
{
    public class UnderwarterHunterRepository : BaseRepository<UnderwaterHunterData>
    {
        public UnderwarterHunterRepository(StoreDbContext dbContext) : base(dbContext) { }

    }
}
