using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Product;

public class UpdateProductDto
{
    [Required]
    public int Id { get; set; }

    [Required]
    [MaxLength(255)]
    public string ProductName { get; set; } = string.Empty;
}