using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeZone.Business.Dtos.SliderDtos;
using TimeZone.Business.Services.Implements;
using TimeZone.Business.Services.Interfaces;
using TimeZone.DAL.Contexts;

namespace TimeZoneApi.Controllers;

[Route("api/[controller]/[action]")]
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
        return StatusCode(StatusCodes.Status201Created);


    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSlider(int id)
    {
        
        await _sliderService.Delete(id);

            return StatusCode(StatusCodes.Status204NoContent);

    }
    [HttpPut("{id}")]
    public async Task<IActionResult>UpdateSlider( int id ,[FromForm] SliderUpdateDto updateDto)
    {
        await _sliderService.UpdateAsnyc(id, updateDto);
        return StatusCode(StatusCodes.Status204NoContent);

        }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetSliderDetail(int id)
    {
       
            return Ok(await _sliderService.GetById(id));
    }
}
