using Microsoft.AspNetCore.Mvc;
using TimeZone.Business.Services.Interfaces;

namespace TimeZoneApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await _userService.GetAllAsync());
    }
    [HttpPost("[action]")]
    public async Task<IActionResult> AddRole(string role, string userName)
    {
        await _userService.AddRole(role, userName);
        return Ok();
    }







}
