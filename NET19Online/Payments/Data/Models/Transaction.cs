namespace Payments.Data.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public decimal Total { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
    }
}
