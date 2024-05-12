using System.ComponentModel.DataAnnotations;

namespace WebDev_Labb2.DataAccess.Entities;

public class Order
{
    [Key]
    public int OrderID { get; set; }
    [Required]
    public int CustomerID { get; set; }
    public DateTime DateOfOrder { get; set; }
    public DateTime? DateOfDelivery { get; set; }
    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}