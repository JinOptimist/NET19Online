using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreData.Models
{
    public class SweetsData : BaseModel
    {
        public string Name { get; set; }
        public string Src { get; set; }
        public virtual List<SweetsCommentsData> Comments { get; set; }
        public virtual List<SweetsTagData> Tags { get; set; } = new List<SweetsTagData> { };
    }
}
