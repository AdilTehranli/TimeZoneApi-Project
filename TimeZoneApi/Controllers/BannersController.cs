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
    public async Task<IActionResult> CreateBanner([FromForm] BannerCreateDto dto)
    {
        await _bannerService.CreateAsnyc(dto);
        return StatusCode(StatusCodes.Status201Created);
      
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBanner(int id)
    {
       
        await _bannerService.Delete(id);
        return StatusCode(StatusCodes.Status204NoContent);

 
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateBanner(int id, [FromForm] BannerUpdateDto updateDto)
    {
      

        await _bannerService.UpdateAsnyc(id, updateDto);
        return StatusCode(StatusCodes.Status200OK);
      
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetBannerDetail(int id)
    {
      
            return Ok(await _bannerService.GetById(id));
    }
}
