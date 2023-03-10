namespace ZeShop.Models
{
    public class Order
    {
        public int? Id { get; set; }
        public List<ProductRow> ProductRows { get; set; }
    }
}
