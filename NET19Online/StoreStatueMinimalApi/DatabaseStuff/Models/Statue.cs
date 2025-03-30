namespace StoreStatueMinimalApi.DatabaseStuff.Models
{
    public class Statue
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Src { get; set; }
        public decimal Cost { get; set; }
    }
}
