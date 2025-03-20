using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreData.Models
{
    public class UnderwaterHunterData : BaseModel
    {
        public string NameHunter { get; set; }
        public string Nationality { get; set; }
        /// <summary>
        /// meters
        /// </summary>
        public int MaxHuntingDepth { get; set; }
        public string Src { get; set; }
        public virtual List<UnderwaterHunterCommentData> Comments { get; set; }
        public virtual List<UnderwaterHunterTagData> Tags { get; set; } = new List<UnderwaterHunterTagData>();
        public int LikesCount { get; set; }
        public int DislikesCount { get; set; }
    }
}
