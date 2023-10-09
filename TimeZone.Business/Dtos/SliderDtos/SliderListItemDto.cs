using Microsoft.AspNetCore.Http;

namespace TimeZone.Business.Dtos.SliderDtos;

public class SliderListItemDto
{
    public int Id { get; set; }
    public string SliderImage { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}
