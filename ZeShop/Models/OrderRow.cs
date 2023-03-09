namespace ZeShop.Models
{
    public class OrderRow
    {
        public int ProductId { get; set; }
        public int Amount { get; set; }
        public Product? Product { get; set; }
    }
}
