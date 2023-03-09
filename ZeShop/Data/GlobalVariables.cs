using ZeShop.Models;

public static class GlobalVariables
{
    public static List<Product> Products { get; set; }
    public static List<Order> Orders { get; set; }
    public static List<Basket> Baskets { get; set; }

    static GlobalVariables()
    {
        Products = new List<Product>();
        Orders = new List<Order>();
        Baskets = new List<Basket>();
    }
}
