using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Item;

public class UpdateItemDto
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    [Range(1, int.MaxValue)]
    public int Quantity { get; set; }
}