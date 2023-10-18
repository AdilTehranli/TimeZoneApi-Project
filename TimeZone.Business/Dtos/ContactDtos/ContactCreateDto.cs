using FluentValidation;
using TimeZone.Core.Entities;

namespace TimeZone.Business.Dtos.ContactDtos;

public class ContactCreateDto
{
    public string Message { get; set; }
    public string Name { get; set; }
    public string MailAddress { get; set; }
    public string Subject { get; set; }
}
public class ContactCreateDtoValidator : AbstractValidator<Contact>
{
    public ContactCreateDtoValidator()
    {
        RuleFor(c=>c.Name).NotEmpty().NotNull();
        RuleFor(c=>c.MailAddress).NotEmpty().NotNull();
        RuleFor(c=>c.Message).NotEmpty().NotNull();
        RuleFor(c=>c.Subject).NotEmpty().NotNull();
    }
}
