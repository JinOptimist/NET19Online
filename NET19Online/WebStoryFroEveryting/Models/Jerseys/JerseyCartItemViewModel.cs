namespace WebStoryFroEveryting.Models.Jerseys
{
    public class JerseyCartItemViewModel
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal Total => Price * Quantity;
    }
}
