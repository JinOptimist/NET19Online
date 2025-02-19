namespace StoreData.Models
{
    public class IdolData : BaseModel
    {
        public string Name { get; set; }
        public string Src { get; set; }
        public int? Age { get; set; }

        public virtual List<IdolCommentData> Comments { get; set; }
        public virtual List<IdolTagData> Tags { get; set; } = new List<IdolTagData>();
    }
}
