using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TimeZone.Business.Dtos.BrandDtos;
using TimeZone.Business.Dtos.ContactDtos;
using TimeZone.Business.Dtos.ProductDtos;
using TimeZone.Business.Services.Implements;
using TimeZone.Business.Services.Interfaces;

namespace TimeZoneApi.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class ContactsController : ControllerBase
{
    readonly IContactService _contactService;

    public ContactsController(IContactService contactService)
    {
        _contactService = contactService;
    }
    [HttpGet]
    public async Task<IActionResult> GetContact()
    {

            return Ok(await _contactService.GetAllAsync());

    }
    [HttpPost]
    
    public async Task<IActionResult> CreateContact([FromForm] ContactCreateDto dto)
    {

            await _contactService.CreateAsnyc(dto);
            return StatusCode(StatusCodes.Status201Created);

        }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteContact(int id)
    {
            await _contactService.Delete(id);
            return StatusCode(StatusCodes.Status204NoContent);

        }
        [HttpGet("{id}")]
    public async Task<IActionResult> GetContactDetail(int id)
    {
            return Ok(await _contactService.GetById(id));
    }
}
