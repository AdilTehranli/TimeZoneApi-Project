﻿using Microsoft.AspNetCore.Mvc;
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
    [HttpGet("VerifyEmail")]
    public async Task<IActionResult> VerifyEmail(string email, string token)
    {
        try
        {
            await _userService.VerifyEmail(email, token);
            // E-posta onaylama başarılıysa, başarılı yanıt döndürün.
            return Ok("Email confirmed successfully");
        }
        catch (NullReferenceException)
        {
            // Kullanıcı bulunamadıysa, 404 Not Found yanıtı döndürün.
            return NotFound("User not found");
        }
        catch (Exception ex)
        {
            // Diğer hatalar için 500 Internal Server Error yanıtı döndürün.
            return StatusCode(500, ex.Message);
        }
    }

}
