using Microsoft.AspNetCore.Mvc;
using RoutineTracker.API.DTO;
using RoutineTracker.API.Service;

namespace RoutineTracker.API.Controller;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }
    
    [HttpPost]
    public IActionResult CreateCategory([FromBody] CategoryInDTO newCategory)
    {
        var category = _categoryService.CreateCategory(newCategory);
        return CreatedAtAction("Category Created", category);
    }

    [HttpGet("{id}")]
    public IActionResult GetCategoryById(int id)
    {
        var category = _categoryService.GetCategoryById(id);
        if (category == null)
        {
            return BadRequest();
        }
        return Ok(category);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateCategoryById(int id, [FromBody] CategoryInDTO updatedCategory)
    {
        var category = _categoryService.UpdateCategoryById(id, updatedCategory);
        if (category == null)
        {
            return BadRequest();
        }
        return Ok(category);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteCategoryById(int id)
    {
        var category = _categoryService.DeleteCategoryById(id);
        return Ok(category);
    }
}