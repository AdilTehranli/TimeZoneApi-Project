using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeZone.Business.Dtos.SliderDtos;
using TimeZone.Business.Services.Interfaces;
using TimeZone.DAL.Contexts;

namespace TimeZoneApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SlidersController : ControllerBase
{
    readonly ISliderService _sliderService;

   
    public SlidersController(ISliderService sliderService)
    {
        _sliderService = sliderService;
    }
    [HttpGet]
    public async Task<IActionResult> GetSlider()
    {
        return Ok(await _sliderService.GetAllAsync());
    }
    [HttpPost]
    public async Task<IActionResult> CreateSlider([FromForm] SliderCreateDto dto)
    {
        await _sliderService.CreateAsnyc(dto);
        return Ok();
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSlider(int id)
    {
        await _sliderService.Delete(id);
        return Ok();
    }
    [HttpPut("{id}")]
    public async Task<IActionResult>UpdateSlider( int id ,[FromForm] SliderUpdateDto updateDto)
    {
        await _sliderService.UpdateAsnyc(id, updateDto);
        return Ok();
    }
}
