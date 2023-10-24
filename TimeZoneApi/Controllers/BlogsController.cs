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
            await _blogService.CreateAsnyc(dto);
        return StatusCode(StatusCodes.Status201Created);
      
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBlog(int id)
    {
      
            await _blogService.Delete(id);
        return StatusCode(StatusCodes.Status204NoContent);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateBlog(int id, [FromForm] BlogUpdateDto updateDto)
    {
       

            await _blogService.UpdateAsnyc(id, updateDto);
            return StatusCode(StatusCodes.Status204NoContent);


    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetBlogDetail(int id)
    {
            return Ok(await _blogService.GetById(id)); 
    }
}
