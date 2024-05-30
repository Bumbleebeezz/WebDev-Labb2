using System.ComponentModel.DataAnnotations;

namespace WebDev_Labb2.Shared.DTOs;

public class OrderDTO
{
    [Required]
    public int CustomerID { get; set; }
    public List<int> Products { get; set; } = new();
}