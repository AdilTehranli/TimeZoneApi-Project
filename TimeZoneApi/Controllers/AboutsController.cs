using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TimeZone.Business.Dtos.AboutDtos;
using TimeZone.Business.Dtos.CategoryDtos;
using TimeZone.Business.Services.Implements;
using TimeZone.Business.Services.Interfaces;

namespace TimeZoneApi.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class AboutsController : ControllerBase
{
    readonly IAboutService  _aboutService;

    public AboutsController(IAboutService aboutService)
    {
        _aboutService = aboutService;
    }
    [HttpGet]
    public async Task<IActionResult> GetAbout()
    {
        return Ok(await _aboutService.GetAllAsync());
    }
    [HttpPost]
    public async Task<IActionResult> CreateAbout([FromForm] AboutCreateDto dto)
    {
        await _aboutService.CreateAsnyc(dto);
        return StatusCode(StatusCodes.Status201Created);
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAbout(int id)
    {

        await _aboutService.Delete(id);
        return StatusCode(StatusCodes.Status204NoContent);


    }
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAbout(int id, [FromForm] AboutUpdateDto updateDto)
    {
        await _aboutService.UpdateAsnyc(id, updateDto);
        return StatusCode(StatusCodes.Status204NoContent);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetAboutDetail(int id)
    {

        return Ok(await _aboutService.GetById(id));
    }
}
