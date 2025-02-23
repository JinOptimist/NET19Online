namespace StoreData.Models
{
    public class UserData : BaseModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public virtual List<IdolCommentData> IdolComments { get; set; }
        public virtual List<JerseyCommentData> JerseyComments { get; set; }
    }
}
