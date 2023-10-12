using Microsoft.AspNetCore.Http;

namespace TimeZone.Business.Dtos.BlogDtos;

public class BlogCreateDto
{
    public IFormFile BlogImage { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}
