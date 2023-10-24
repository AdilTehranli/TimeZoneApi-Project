using Microsoft.AspNetCore.Mvc;
using TimeZone.Business.Dtos.BrandDtos;
using TimeZone.Business.Dtos.SliderDtos;
using TimeZone.Business.Services.Implements;
using TimeZone.Business.Services.Interfaces;

namespace TimeZoneApi.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class BrandsController : ControllerBase
{
    readonly IBrandService _brandService;

    public BrandsController(IBrandService brandService)
    {
        _brandService = brandService;
    }
    [HttpGet]
    public async Task<IActionResult> GetBrand()
    {
            return Ok(await _brandService.GetAllAsync()); 
    }
    [HttpPost]
    public async Task<IActionResult> CreateBrand([FromForm] BrandCreateDto dto)
    {
            await _brandService.CreateAsnyc(dto);
        return StatusCode(StatusCodes.Status201Created);
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBrand(int id)
    {
            await _brandService.Delete(id);
        return StatusCode(StatusCodes.Status204NoContent);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateBrand(int id,  BrandUpdateDto updateDto)
    {
            await _brandService.UpdateAsnyc(id, updateDto);
         return StatusCode(StatusCodes.Status204NoContent);

    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetBrandDetail(int id)
    {
            return Ok(await _brandService.GetById(id));
    }
}
