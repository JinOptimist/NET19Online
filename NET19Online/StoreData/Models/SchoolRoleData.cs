using Enums.SchoolUser;

namespace StoreData.Models;

public class SchoolRoleData : BaseModel
{
    public string Name { get; set; }

    public SchoolPermission Permisson { get; set; }

    public List<SchoolUserData> Users { get; set; } = [];
}