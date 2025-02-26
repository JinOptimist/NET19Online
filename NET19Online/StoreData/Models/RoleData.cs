using Enums.User;

namespace StoreData.Models
{
    public class RoleData : BaseModel
    {
        public string Name { get; set; }
        
        public Permisson Permisson { get; set; }

        public virtual List<UserData> Users { get; set; }
    }
}
