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
        try
        {

            return Ok(await _brandService.GetAllAsync());
        }
        catch (Exception)
        {

            throw new ArgumentException("Data getirile bilmedi");
        }
    }
    [HttpPost]
    public async Task<IActionResult> CreateBrand( BrandCreateDto dto)
    {
        try
        {

            await _brandService.CreateAsnyc(dto);
        }
        catch (Exception)
        {

            throw new ArgumentException("Yaradila bilmedi");
        }
        return Ok();
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBrand(int id)
    {
        try
        {
            await _brandService.Delete(id);

        }
        catch (Exception)
        {

            throw new ArgumentException("Siline bilmedi");
        }
        return Ok();
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateBrand(int id,  BrandUpdateDto updateDto)
    {
        try
        {

            await _brandService.UpdateAsnyc(id, updateDto);
        }
        catch (Exception)
        {

            throw new ArgumentException("Deyisdirile bilmedi");
        }
        return Ok();
    }
}
