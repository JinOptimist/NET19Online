using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace StoreData.Models
{
    public class JerseyCommentData : BaseModel
    {
        public DateTime Created { get; set; }
        public string Comment { get; set; }

        public virtual JerseyData Jersey { get; set; }
        public virtual UserData? Author {  get; set; }
    }
}
