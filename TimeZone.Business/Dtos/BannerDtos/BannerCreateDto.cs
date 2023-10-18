using FluentValidation;
using Microsoft.AspNetCore.Http;
using TimeZone.Core.Entities;

namespace TimeZone.Business.Dtos.BannerDto;

public class BannerCreateDto
{
    public IFormFile BannerImage { get; set; }
    public string Title { get; set; }
    public double Price { get; set; }
}
public class BannerCreateValidator : AbstractValidator<Banner>
{
    public BannerCreateValidator()
    {
        RuleFor(b => b.BannerImage).NotEmpty().NotNull();
        RuleFor(b => b.Title).NotEmpty().NotNull();
        RuleFor(b => b.Price).NotEmpty().NotNull();
    }
}
