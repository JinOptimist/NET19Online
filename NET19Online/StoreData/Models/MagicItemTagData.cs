using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreData.Models
{
    public class MagicItemTagData : BaseModel
    {
        public string Tag { get; set; }

        public virtual List<MagicItemData> MagicItems { get; set; }
    }
}
