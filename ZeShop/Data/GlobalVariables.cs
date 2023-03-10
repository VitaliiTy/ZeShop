using ZeShop.Models;

public static class GlobalVariables
{
    public static List<Product> Products { get; set; }
    public static List<Order> Orders { get; set; }
    public static Basket Basket { get; set; }

    static GlobalVariables()
    {
        Products = new List<Product>();
        Orders = new List<Order>();
        Basket = new Basket();

        Products.Add(new Product { Id = 1,Name = "Product 1", Price = 123, Amount = 10 });
        Products.Add(new Product { Id = 2, Name = "Product 2", Price = 234, Amount = 1 });
        Products.Add(new Product { Id = 3, Name = "Product 3", Price = 56, Amount = 110 });
        Products.Add(new Product { Id = 4, Name = "Product 4", Price = 45, Amount = 10 });
        Products.Add(new Product { Id = 5, Name = "Product 5", Price = 65, Amount = 150 });
        Products.Add(new Product { Id = 6, Name = "Product 6", Price = 234, Amount = 140 });
        Products.Add(new Product { Id = 7, Name = "Product 7", Price = 67, Amount = 3 });
        Products.Add(new Product { Id = 8,  Name = "Product 8", Price = 123, Amount = 110 });
    }
}
