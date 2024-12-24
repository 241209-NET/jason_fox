using Microsoft.AspNetCore.Mvc;
using RoutineTracker.API.DTO;
using RoutineTracker.API.Service;

namespace RoutineTracker.API.Controller;

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
}