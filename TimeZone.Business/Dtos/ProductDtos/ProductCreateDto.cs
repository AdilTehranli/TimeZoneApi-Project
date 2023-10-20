using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace TimeZone.Business.Dtos.ProductDtos;

public class ProductCreateDto
{
    public  IFormFile  ProductImage { get; set; }
    public string Title { get; set; }
    public double Price { get; set; }
    public string Description { get; set; }

    public int CategoryId { get; set; }
    public int BrandId { get; set; }
}
public class ProductCreateDtoValidator : AbstractValidator<ProductCreateDto>
{
    public ProductCreateDtoValidator()
    {
        RuleFor(p=>p.ProductImage).NotEmpty().NotNull();
        RuleFor(p=>p.Title).NotEmpty().NotNull().MaximumLength(255);
        RuleFor(p=>p.Price).NotEmpty().NotNull();
    }
}
