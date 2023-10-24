using Microsoft.AspNetCore.Mvc;
using TimeZone.Business.Dtos.CategoryDtos;
using TimeZone.Business.Dtos.WrapperDtos;
using TimeZone.Business.Services.Implements;
using TimeZone.Business.Services.Interfaces;

namespace TimeZoneApi.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class WrappersController : ControllerBase
{
    readonly IWrapperService _wrapperService;

    public WrappersController(IWrapperService wrapperService)
    {
        _wrapperService = wrapperService;
    }
    [HttpGet]
    public async Task<IActionResult> GetWrapper()
    {
            return Ok(await _wrapperService.GetAllAsync());
    }
    [HttpPost]
    public async Task<IActionResult> CreateWrapper(WrapperCreateDto dto)
    {
      

            await _wrapperService.CreateAsnyc(dto);
        return StatusCode(StatusCodes.Status201Created);



    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteWrapper(int id)
    {
       
            await _wrapperService.Delete(id);
            return StatusCode(StatusCodes.Status204NoContent);

        }
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateWrapper(int id, WrapperUpdateDto updateDto)
    {
            await _wrapperService.UpdateAsnyc(id, updateDto);
            return StatusCode(StatusCodes.Status204NoContent);
        }
}
