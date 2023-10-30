using Microsoft.AspNetCore.Mvc;
using TimeZone.Business.Dtos.BrandDtos;
using TimeZone.Business.Dtos.CategoryDtos;
using TimeZone.Business.Services.Implements;
using TimeZone.Business.Services.Interfaces;

namespace TimeZoneApi.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    readonly ICategoryService _categoryService;

    public CategoriesController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }
    [HttpGet]
    public async Task<IActionResult> GetCategory()
    {
            return Ok(await _categoryService.GetAllAsync()); 
    }
    [HttpPost]
    public async Task<IActionResult> CreateCategory([FromForm] CategoryCreateDto dto)
    {


        await _categoryService.CreateAsnyc(dto);
        return StatusCode(StatusCodes.Status201Created);


    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCategory(int id)
    {
   
            await _categoryService.Delete(id);
        return StatusCode(StatusCodes.Status204NoContent);


    }
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCategory(int id,[FromForm] CategoryUpdateDto updateDto)
    {
   

            await _categoryService.UpdateAsnyc(id, updateDto);
            return StatusCode(StatusCodes.Status204NoContent);

    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetCategoryDetail(int id)
    {
            return Ok(await _categoryService.GetById(id));
    }
}