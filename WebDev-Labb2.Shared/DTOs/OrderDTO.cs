using System.ComponentModel.DataAnnotations;
using WebDev_Labb2.DataAccess.Entities;

namespace WebDev_Labb2.Shared.DTOs;

public class OrderDTO
{
    [Required]
    public int CustomerID { get; set; }
    [Required]
    public DateTime DateOfOrder { get; set; }
    public DateTime DateOfDelivery { get; set; }
    public List<Product> Products { get; set; }
}