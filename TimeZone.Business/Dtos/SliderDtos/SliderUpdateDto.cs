using Microsoft.AspNetCore.Http;

namespace TimeZone.Business.Dtos.SliderDtos;

public class SliderUpdateDto
{  
    public IFormFile SliderImage { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}
