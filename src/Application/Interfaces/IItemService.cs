using Application.DTOs.Item;

namespace Application.Interfaces;

public interface IItemService
{
    Task<IEnumerable<ItemDto>> GetByProductIdAsync(int productId);

    Task<ItemDto> CreateAsync(CreateItemDto dto);

    Task<bool> UpdateAsync(int id, UpdateItemDto dto);

    Task<bool> DeleteAsync(int id);
}