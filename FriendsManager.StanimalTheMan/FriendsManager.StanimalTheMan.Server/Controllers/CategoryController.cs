using FriendsManager.StanimalTheMan.Server.Models;
using FriendsManager.StanimalTheMan.Server.Services;
using Microsoft.AspNetCore.Mvc;

namespace FriendsManager.StanimalTheMan.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController : Controller
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
    {
        try
        {
            var categories = await _categoryService.GetAllCategoriesAsync();
            return Ok(categories);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Category>> GetCategoryById(int id)
    {
        try
        {
            var category = await _categoryService.GetCategoryByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpPost]
    public async Task<ActionResult<Category>> AddCategory(Category category)
    {
        try
        {
            await _categoryService.AddCategoryAsync(category);
            return CreatedAtAction(nameof(GetCategoryById), new { id = category.CategoryID }, category);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCategory(int id, Category category)
    {
        if (id != category.CategoryID)
        {
            return BadRequest("Category ID mismatch");
        }

        try
        {
            await _categoryService.UpdateCategoryAsync(category);
            return NoContent();
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCategory(int id)
    {
        try
        {
            var category = await _categoryService.GetCategoryByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            await _categoryService.DeleteCategoryAndFriendsAsync(category);
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}
