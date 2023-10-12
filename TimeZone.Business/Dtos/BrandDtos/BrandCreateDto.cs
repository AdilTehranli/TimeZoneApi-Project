using FluentValidation;

namespace TimeZone.Business.Dtos.BrandDtos;

public class BrandCreateDto
{
    public string Name { get; set; }
}
public class BrandCreateDtoValidator : AbstractValidator<BrandCreateDto>
{
    public BrandCreateDtoValidator()
    {
        RuleFor(x => x.Name).NotEmpty().NotEmpty().MaximumLength(30);
    }
}
