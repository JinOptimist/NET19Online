using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreData.Models
{
    public class PlayerData : BaseModel
    {
        public string Name { get; set; }
        public string Src { get; set; }
        public string Position { get; set; }
        public int Weight { get; set; }
        public int Height { get; set; }

        public virtual List<PlayerDescriptionData> Descriptions { get; set; }
        public virtual List<PlayerTagData> Tags { get; set; } = new();
    }
}
