namespace WebDev_Labb2.DataAccess.Entities;

public class Order
{
    public int OrderID { get; set; }
    public int CustomerID { get; set; }
    public DateTime DateOfOrder { get; set; }
    public bool OrderShipped { get; set; }
    public List<int> Products { get; set; } = new();
}