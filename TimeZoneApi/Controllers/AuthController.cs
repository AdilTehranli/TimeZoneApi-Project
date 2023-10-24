using Microsoft.AspNetCore.Mvc;
using TimeZone.Business.Dtos.UserDtos;
using TimeZone.Business.Services.Interfaces;

namespace TimeZoneApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    readonly IUserService _userService;

    public AuthController(IUserService userService)
    {
        _userService = userService;
    }
    [HttpPost("[action]")]
    public async Task<IActionResult> Register([FromForm]RegisterDto dto)
    {
        await _userService.RegisterAsync(dto);
        return StatusCode(StatusCodes.Status201Created);
    }
    [HttpPost("[action]")]
    public async Task<IActionResult> Login([FromBody] LoginDto dto)
    {
       return Ok( await _userService.LoginAsync(dto));
     

    }
}
