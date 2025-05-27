namespace Payments.DTO
{
    public class AddTransactionRequest
    {
        public int OwnerId { get; set; }
        public decimal Total { get; set; }
    }
}
