namespace StoreData.Models
{
    public class UserData : BaseModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public virtual RoleData? Role { get; set; }

        public virtual List<IdolCommentData> IdolComments { get; set; }
        public virtual List<JerseyCommentData> JerseyComments { get; set; }
        public virtual List<UnderwaterHunterCommentData> HunterComments { get; set; }
        public virtual List<PlayerDescriptionData> PlayerDescriptions { get; set; }
        public virtual List<NotebookCommentData> NotebookComments { get; set; }
    }
}
