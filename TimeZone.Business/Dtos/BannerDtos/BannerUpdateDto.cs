using Microsoft.AspNetCore.Http;

namespace TimeZone.Business.Dtos.BannerDto;

public class BannerUpdateDto
{
    public IFormFile BannerImage { get; set; }
    public string Title { get; set; }
    public double Price { get; set; }
}
