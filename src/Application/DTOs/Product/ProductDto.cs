using Application.DTOs.Item;

namespace Application.DTOs.Product;

public class ProductDto
{
    public int Id { get; set; }

    public string ProductName { get; set; } = string.Empty;

    public List<ItemDto> Items { get; set; } = new();
}