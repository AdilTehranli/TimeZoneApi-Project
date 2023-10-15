using FluentValidation;

namespace TimeZone.Business.Dtos.WrapperDtos;

public class WrapperCreateDto
{
    public string Icon { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}
public class WrapperCreateDtoValidator : AbstractValidator<WrapperCreateDto>
{
    public WrapperCreateDtoValidator()
    {
        RuleFor(w => w.Icon).NotEmpty().NotNull();
        RuleFor(w => w.Title).NotEmpty().NotNull();
        RuleFor(w => w.Description).NotEmpty().NotNull();
    }
}