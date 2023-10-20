using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeZone.Business.Dtos.SliderDtos;
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
        try
        {

        return Ok(await _sliderService.GetAllAsync());
        }
        catch (Exception)
        {

            throw new ArgumentException("Data getirile bilmedi");
        }
    }
    [HttpPost]
    public async Task<IActionResult> CreateSlider([FromForm] SliderCreateDto dto)
    {
        try
        {

        await _sliderService.CreateAsnyc(dto);
        }
        catch (Exception)
        {

            throw new ArgumentException("Yaradila bilmedi");
        }
        return Ok();
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSlider(int id)
    {
        try
        {
        await _sliderService.Delete(id);

        }
        catch (Exception)
        {

            throw new ArgumentException("Siline bilmedi");
        }
        return Ok();
    }
    [HttpPut("{id}")]
    public async Task<IActionResult>UpdateSlider( int id ,[FromForm] SliderUpdateDto updateDto)
    {
        try
        {

        await _sliderService.UpdateAsnyc(id, updateDto);
        }
        catch (Exception)
        {

            throw new ArgumentException("Deyisdirile bilmedi");
        }
        return Ok();
    }
}
