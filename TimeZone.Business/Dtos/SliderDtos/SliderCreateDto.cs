using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace TimeZone.Business.Dtos.SliderDtos;

public class SliderCreateDto
{
        
    public IFormFile SliderImage { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}
public class SliderCreateDtoValidator: AbstractValidator
