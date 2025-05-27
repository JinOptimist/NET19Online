namespace Payments.DTO
{
    public class AddBalanceRequest
    {
        public int OwnerId { get; set; }
        public decimal Amount { get; set; }
    }
}
