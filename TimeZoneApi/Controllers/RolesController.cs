using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TimeZone.Business.Services.Interfaces;

namespace TimeZoneApi.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class RolesController : ControllerBase
{
    readonly IRoleService _roleService;

    public RolesController(IRoleService roleService)
    {
        _roleService = roleService;
    }
    [HttpGet]
    public async Task<IActionResult> GetRole()
    {
        return Ok(await _roleService.GetAllAsync());
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdRole(string id)
    {
        return Ok(await _roleService.GetById(id));
    }
    [HttpPost]
    public async Task<IActionResult>  CreateRole(string name)
    {
        await _roleService.CreateAsnyc(name);
        return StatusCode(StatusCodes.Status201Created);
    }
    [HttpDelete]
    public async Task<IActionResult> DeleteRole(string id)
    {
        await _roleService.Delete(id);
        return StatusCode(StatusCodes.Status204NoContent);
    }
    [HttpPut]
    public async Task<IActionResult> UpdateRole(string id, string name)
    {
        await _roleService.UpdateAsnyc(id, name);
        return StatusCode(StatusCodes.Status204NoContent);
    }
}
