using Microsoft.AspNetCore.Http;

namespace TimeZone.Business.Dtos.BlogDtos;

public class BlogListItemDto
{
    public int Id { get; set; }
    public IFormFile BlogImage { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}
