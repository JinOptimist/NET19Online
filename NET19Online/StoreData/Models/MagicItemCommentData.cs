using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreData.Models
{
    public class MagicItemCommentData : BaseModel
    {
        public DateTime Created { get; set; }
        public string Comment { get; set; }

        public virtual MagicItemData MagicItem { get; set; }
        public virtual UserData? Author { get; set; }
    }
}
