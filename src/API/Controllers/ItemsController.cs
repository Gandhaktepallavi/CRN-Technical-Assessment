using Application.DTOs.Item;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api")]
public class ItemsController : ControllerBase
{
    private readonly IItemService _itemService;

    public ItemsController(IItemService itemService)
    {
        _itemService = itemService;
    }

    /// <summary>
    /// Get all items for a product
    /// </summary>
    /// <param name="productId"></param>
    /// <returns></returns>
    [HttpGet("products/{productId:int}/items")]
    public async Task<IActionResult> GetByProduct(int productId)
    {
        var items = await _itemService.GetByProductIdAsync(productId);

        return Ok(items);
    }

    /// <summary>
    /// Create a new item for a product
    /// </summary>
    /// <param name="productId"></param>
    /// <param name="dto"></param>
    /// <returns></returns>
    [HttpPost("products/{productId:int}/items")]
    public async Task<IActionResult> Create(int productId, CreateItemDto dto)
    {
        dto.ProductId = productId;

        var item = await _itemService.CreateAsync(dto);

        return CreatedAtAction(
            nameof(GetByProduct),
            new { productId = item.ProductId },
            item);
    }

    /// <summary>
    /// Update an existing item
    /// </summary>
    /// <param name="id"></param>
    /// <param name="dto"></param>
    /// <returns></returns>
    [HttpPut("items/{id:int}")]
    public async Task<IActionResult> Update(int id, UpdateItemDto dto)
    {
        if (id != dto.Id)
            return BadRequest("Id mismatch.");

        var updated = await _itemService.UpdateAsync(id, dto);

        if (!updated)
            return NotFound();

        return NoContent();
    }

    /// <summary>
    /// Delete an item
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("items/{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _itemService.DeleteAsync(id);

        if (!deleted)
            return NotFound();

        return NoContent();
    }
}