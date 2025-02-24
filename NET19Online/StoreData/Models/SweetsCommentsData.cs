using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreData.Models
{
    public class SweetsCommentsData : BaseModel
    {
        public DateTime Created { get; set; }
        public string Comment { get; set; }
        public virtual SweetsData Sweets { get; set; }

    }
}
