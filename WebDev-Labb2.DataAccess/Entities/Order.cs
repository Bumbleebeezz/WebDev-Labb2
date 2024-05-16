using System.ComponentModel.DataAnnotations;

namespace WebDev_Labb2.DataAccess.Entities;

public class Order
{
    [Key]
    public int OrderID { get; set; }
    [Required]
    public int CustomerID { get; set; }
    public DateTime DateOfOrder { get; set; }
    public bool OrderShipped { get; set; }
    public List<Product> Products { get; set; } = new();
}