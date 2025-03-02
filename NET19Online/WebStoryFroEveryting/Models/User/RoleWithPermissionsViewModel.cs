using Enums.User;

namespace WebStoryFroEveryting.Models.User
{
    public class RoleWithPermissionsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Permisson> Permissons {  get; set; }
    }
}
