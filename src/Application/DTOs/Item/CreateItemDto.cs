using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Item;

public class CreateItemDto
{
    public int ProductId { get; set; }

    [Range(1, int.MaxValue)]
    public int Quantity { get; set; }
}