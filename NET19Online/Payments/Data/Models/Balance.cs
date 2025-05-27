namespace Payments.Data.Models
{
    public class Balance
    {
        public int Id { get; set; }
        public int OwnerId { get; set; }
        public decimal Total { get; set; }
    }
}
