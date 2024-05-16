using System.ComponentModel.DataAnnotations;

namespace WebDev_Labb2.Shared.DTOs;

public class CustomerDTO
{
    [Required]
    public string Firstname { get; set; }
    [Required]
    public string Lastname { get; set; }
    [Required]
    public string Address { get; set; }
    [Required,EmailAddress]
    public string Email { get; set; }
    [Required,Phone]
    public string Phone { get; set; }
}