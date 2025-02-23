namespace StoreData.Models
{
    public class MagicItemData : BaseModel
    {
        public string Name { get; set; }
        public string Src { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public int ItemsInStock { get; set; }
        public virtual List<MagicItemCommentData> Comments { get; set; }
        public virtual List<MagicItemTagData> Tags { get; set; } = new List<MagicItemTagData>();
    }
}
