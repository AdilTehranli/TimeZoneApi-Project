using FluentValidation;

namespace TimeZone.Business.Dtos.CategoryDtos;

public class CategoryCreateDto
{
    public string Name { get; set; }
}
public class CategoryCreateDtoValidator : AbstractValidator<CategoryCreateDto>
{
    public CategoryCreateDtoValidator()
    {
        RuleFor(c=>c.Name).NotEmpty().NotNull().MaximumLength(50);
    }
}
