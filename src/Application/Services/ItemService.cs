using Application.DTOs.Item;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;

namespace Application.Services;

public class ItemService : IItemService
{
    private readonly IItemRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ItemService(
        IItemRepository repository,
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ItemDto>> GetByProductIdAsync(int productId)
    {
        var items = await _repository.GetByProductIdAsync(productId);
        return _mapper.Map<IEnumerable<ItemDto>>(items);
    }

    public async Task<ItemDto> CreateAsync(CreateItemDto dto)
    {
        var item = _mapper.Map<Item>(dto);

        item.CreatedBy = "System";
        item.CreatedOn = DateTime.UtcNow;

        await _repository.AddAsync(item);
        await _unitOfWork.SaveChangesAsync();

        return _mapper.Map<ItemDto>(item);
    }

    public async Task<bool> UpdateAsync(int id, UpdateItemDto dto)
    {
        var item = await _repository.GetByIdAsync(id);

        if (item == null)
            return false;

        item.Quantity = dto.Quantity;
        item.ModifiedBy = "System";
        item.ModifiedOn = DateTime.UtcNow;

        _repository.Update(item);

        await _unitOfWork.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var item = await _repository.GetByIdAsync(id);

        if (item == null)
            return false;

        _repository.Delete(item);

        await _unitOfWork.SaveChangesAsync();

        return true;
    }
}