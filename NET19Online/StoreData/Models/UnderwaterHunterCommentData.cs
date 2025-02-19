using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreData.Models
{
    public class UnderwaterHunterCommentData : BaseModel
    {
        public DateTime Create { get; set; }
        public string Comment { get; set; }
        public virtual UnderwaterHunterData HunterId { get; set; }
    }
}
