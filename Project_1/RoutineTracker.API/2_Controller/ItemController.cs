using Microsoft.AspNetCore.Mvc;
using RoutineTracker.API.DTO;
using RoutineTracker.API.Service;

namespace RoutineTracker.API.Controller;

[Route("api/[controller]")]
[ApiController]
public class ItemController : ControllerBase
{
    private readonly IItemService _itemService;

    public ItemController(IItemService itemService)
    {
        _itemService = itemService;
    }

    [HttpPost]
    public IActionResult CreateItem([FromBody] ItemInDTO newItem)
    {
        var item = _itemService.CreateItem(newItem);
        return CreatedAtAction("Item Created", item);
    }

    [HttpGet("{id}")]
    public IActionResult GetItemById(int id)
    {
        var item = _itemService.GetItemById(id);
        if (item == null)
        {
            return NotFound();
        }
        return Ok(item);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateItemById(int id, [FromBody] ItemInDTO updatedItem)
    {
        var item = _itemService.UpdateItemById(id, updatedItem);
        if (item == null)
        {
            return NotFound();
        }
        return Ok(item);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteItemById(int id)
    {
        var item = _itemService.DeleteItemById(id);
        if (item == null)
        {
            return NotFound();
        }
        return Ok(item);
    }

    [HttpGet("category/{categoryId}")]
    public IActionResult GetItemsByCategoryId(int categoryId)
    {
        var items = _itemService.GetItemsByCategoryId(categoryId);
        return Ok(items);
    }

    [HttpGet("user/{userId}")]
    public IActionResult GetItemsByUserId(int userId)
    {
        var items = _itemService.GetItemsByUserId(userId);
        return Ok(items);
    }

    [HttpPost("{itemId}/category/{categoryId}")]
    public IActionResult AddItemToCategory(int itemId, int categoryId)
    {
        var item = _itemService.AddItemToCategory(itemId, categoryId);
        if (item == null)
        {
            return NotFound();
        }
        return Ok(item);
    }

    [HttpDelete("{itemId}/category/{categoryId}")]
    public IActionResult RemoveItemFromCategory(int itemId, int categoryId)
    {
        var item = _itemService.RemoveItemFromCategory(itemId, categoryId);
        if (item == null)
        {
            return NotFound();
        }
        return Ok(item);
    }
}