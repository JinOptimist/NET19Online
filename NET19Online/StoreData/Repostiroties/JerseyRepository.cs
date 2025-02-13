using StoreData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreData.Repostiroties
{
    public class JerseyRepository : BaseRepository<JerseyData>
    {
        public JerseyRepository(StoreDbContext dbContext) : base(dbContext) { }
        
    }
}
