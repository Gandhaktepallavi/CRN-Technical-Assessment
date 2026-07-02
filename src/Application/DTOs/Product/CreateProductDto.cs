using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Product;

public class CreateProductDto
{
    [Required]
    [MaxLength(255)]
    public string ProductName { get; set; } = string.Empty;
}