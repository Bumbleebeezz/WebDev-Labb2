using System.ComponentModel.DataAnnotations;

namespace WebDev_Labb2.Shared.DTOs;

public class ProductDTO
{
    [Required]
    public string Name { get; set; }
    [Required]
    public string EAN { get; set; }
    [Required]
    public float Price { get; set; }
    [Required]
    public string Category { get; set; }
    [Required]
    public string Description { get; set; }
}