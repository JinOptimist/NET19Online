using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreData.Models
{
    public class PlayerDescriptionData : BaseModel
    {
        public string Description { get; set; }
        public virtual PlayerData Player { get; set; }
        public virtual UserData? Author { get; set; }
    }
}
