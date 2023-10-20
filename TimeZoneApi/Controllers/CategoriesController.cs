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
        try
        {

            return Ok(await _categoryService.GetAllAsync());
        }
        catch (Exception)
        {

            throw new ArgumentException("Data getirile bilmedi");
        }
    }
    [HttpPost]
    public async Task<IActionResult> CreateCategory([FromForm] CategoryCreateDto dto)
    {


        await _categoryService.CreateAsnyc(dto);
        return Ok();

    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCategory(int id)
    {
        try
        {
            await _categoryService.Delete(id);

        }
        catch (Exception)
        {

            throw new ArgumentException("Siline bilmedi");
        }
        return Ok();
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateBrand(int id, CategoryUpdateDto updateDto)
    {
        try
        {

            await _categoryService.UpdateAsnyc(id, updateDto);
        }
        catch (Exception)
        {

            throw new ArgumentException("Deyisdirile bilmedi");
        }
        return Ok();
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetCategoryDetail(int id)
    {
        try
        {
            return Ok(await _categoryService.GetById(id));
        }
        catch (Exception)
        {

            throw new ArgumentException("Product id gelmedi");
        }
    }
}