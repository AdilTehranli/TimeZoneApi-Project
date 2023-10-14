using Microsoft.AspNetCore.Mvc;
using TimeZone.Business.Dtos.BlogDtos;
using TimeZone.Business.Dtos.ProductDtos;
using TimeZone.Business.Services.Implements;
using TimeZone.Business.Services.Interfaces;

namespace TimeZoneApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BlogsController : ControllerBase
{
    readonly IBlogService _blogService;

    public BlogsController(IBlogService blogService)
    {
        _blogService = blogService;
    }

    [HttpGet]
    public async Task<IActionResult> GetBlog()
    {
        

            return Ok(await _blogService.GetAllAsync());
        
       
    }
    [HttpPost]
    public async Task<IActionResult> CreateBlog([FromForm] BlogCreateDto dto)
    {
        try
        {

            await _blogService.CreateAsnyc(dto);
        }
        catch (Exception)
        {

            throw new ArgumentException("Yaradila bilmedi");
        }
        return Ok();
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBlog(int id)
    {
        try
        {
            await _blogService.Delete(id);

        }
        catch (Exception)
        {

            throw new ArgumentException("Siline bilmedi");
        }
        return Ok();
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateBlog(int id, [FromForm] BlogUpdateDto updateDto)
    {
        try
        {

            await _blogService.UpdateAsnyc(id, updateDto);
        }
        catch (Exception)
        {

            throw new ArgumentException("Deyisdirile bilmedi");
        }
        return Ok();
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetBlogDetail(int id)
    {
        try
        {
            return Ok(await _blogService.GetById(id));
        }
        catch (Exception)
        {

            throw new ArgumentException("Product id gelmedi");
        }
    }
}
