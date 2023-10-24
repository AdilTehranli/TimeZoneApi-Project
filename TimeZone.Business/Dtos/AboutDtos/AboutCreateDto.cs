using FluentValidation;
using TimeZone.Core.Entities;

namespace TimeZone.Business.Dtos.AboutDtos;

public class AboutCreateDto
{
    public string Title { get; set; }
    public string Description { get; set; }
}
public class AboutCreateDtoValidator : AbstractValidator<About>
{
    public AboutCreateDtoValidator()
    {
        RuleFor(a=>a.Title).NotEmpty().NotNull();
        RuleFor(a=>a.Description).NotEmpty().NotNull();
    }
}
