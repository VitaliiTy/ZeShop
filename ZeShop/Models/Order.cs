namespace ZeShop.Models
{
    public class Order
    {
        public int? Id { get; set; }
        public List<OrderRow> OrderRows { get; set; }
    }
}
