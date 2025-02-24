using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreData.Models
{
    public class UnderwaterHunterTagData : BaseModel
    {
        public string Tag { get; set; }
        public virtual List<UnderwaterHunterData> Hunters { get; set; }
    }
}
