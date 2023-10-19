using Microsoft.AspNetCore.Mvc;
using TimeZone.Business.Dtos.BannerDto;
using TimeZone.Business.Dtos.BrandDtos;
using TimeZone.Business.Services.Implements;
using TimeZone.Business.Services.Interfaces;

namespace TimeZoneApi.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class BannersController : ControllerBase
{
    readonly IBannerService _bannerService;

    public BannersController(IBannerService bannerService)
    {
        _bannerService = bannerService;
    }
    [HttpGet]
    public async Task<IActionResult> GetBanner()
    {

            return Ok(await _bannerService.GetAllAsync());
      
    }
    [HttpPost]
    public async Task<IActionResult> CreateBrand([FromForm] BannerCreateDto dto)
    {
        try
        {

            await _bannerService.CreateAsnyc(dto);
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
            await _bannerService.Delete(id);

        }
        catch (Exception)
        {

            throw new ArgumentException("Siline bilmedi");
        }
        return Ok();
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateBanner(int id, [FromForm] BannerUpdateDto updateDto)
    {
        try
        {

            await _bannerService.UpdateAsnyc(id, updateDto);
        }
        catch (Exception)
        {

            throw new ArgumentException("Deyisdirile bilmedi");
        }
        return Ok();
    }

}
