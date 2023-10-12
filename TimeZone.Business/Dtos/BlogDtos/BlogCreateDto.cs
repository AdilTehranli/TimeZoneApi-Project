using FluentValidation;
using Microsoft.AspNetCore.Http;
using TimeZone.Core.Entities;

namespace TimeZone.Business.Dtos.BlogDtos;

public class BlogCreateDto
{
    public IFormFile BlogImage { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}
public class BlogCreateDtoValidator : AbstractValidator<Blog>
{
    public BlogCreateDtoValidator()
    {
       RuleFor(b=>b.BlogImage).NotEmpty().NotNull();
       RuleFor(b=>b.Title).NotEmpty().NotNull();
       RuleFor(b=>b.Description).NotEmpty().NotNull();
    }
}