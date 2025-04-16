using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreData.Models
{
    public class SingerCommentData : BaseModel
    {
        public string Comment {  get; set; }
        public DateTime CreatedDate { get; set; }
        public virtual SingerData Singer { get; set; }

    }
}
