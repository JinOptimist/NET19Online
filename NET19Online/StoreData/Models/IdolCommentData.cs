namespace StoreData.Models
{
    public class IdolCommentData : BaseModel
    {
        public DateTime Created { get; set; }
        public string Comment { get; set; }

        public virtual IdolData Idol { get; set; }
    }
}
