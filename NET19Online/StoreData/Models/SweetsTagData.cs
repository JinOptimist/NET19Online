using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreData.Models
{
    public class SweetsTagData : BaseModel
    {
        public string Tag { get; set; }
        public List<SweetsData> Sweets { get; set; }
    }
}
