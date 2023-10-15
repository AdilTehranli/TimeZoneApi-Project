using Microsoft.AspNetCore.Mvc;
using TimeZone.Business.Dtos.CategoryDtos;
using TimeZone.Business.Dtos.WrapperDtos;
using TimeZone.Business.Services.Implements;
using TimeZone.Business.Services.Interfaces;

namespace TimeZoneApi.Controllers;

[Route("api/[controller]")]
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
        try
        {

            return Ok(await _wrapperService.GetAllAsync());
        }
        catch (Exception)
        {

            throw new ArgumentException("Data getirile bilmedi");
        }
    }
    [HttpPost]
    public async Task<IActionResult> CreateWrapper(WrapperCreateDto dto)
    {
      

            await _wrapperService.CreateAsnyc(dto);
        return Ok();
        
       
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteWrapper(int id)
    {
        try
        {
            await _wrapperService.Delete(id);

        }
        catch (Exception)
        {

            throw new ArgumentException("Siline bilmedi");
        }
        return Ok();
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateWrapper(int id, WrapperUpdateDto updateDto)
    {
        try
        {

            await _wrapperService.UpdateAsnyc(id, updateDto);
        }
        catch (Exception)
        {

            throw new ArgumentException("Deyisdirile bilmedi");
        }
        return Ok();
    }
}
