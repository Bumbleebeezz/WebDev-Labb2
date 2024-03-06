namespace WebDev_Labb2.DataAccess.Entities;

public class Order
{
    public int OrderID { get; set; }
    public int CustomerID { get; set; }
    public DateTime DateOfOrder { get; set; }
    public DateTime DateOfDelivery { get; set; }
    public List<Product> Products { get; set; }
}