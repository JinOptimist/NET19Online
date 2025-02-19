namespace StoreData.Models
{
    public class IdolTagData : BaseModel
    {
        public string Tag {  get; set; }

        public virtual List<IdolData> Idols { get; set; }
    }
}
