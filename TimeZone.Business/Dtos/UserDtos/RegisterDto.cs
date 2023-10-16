using FluentValidation;
using System.Text.RegularExpressions;

namespace TimeZone.Business.Dtos.UserDtos;
public record RegisterDto
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email  { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string RepeatPassword { get; set; }
}
public class RegisterDtosValidator : AbstractValidator<RegisterDto>
{
    public RegisterDtosValidator()
    {
        RuleFor(u => u.Name)
     .NotEmpty()
     .NotNull()
     .MinimumLength(2)
     .MaximumLength(25);
        RuleFor(u => u.Surname)
            .NotEmpty()
            .NotNull()
            .MinimumLength(2)
            .MaximumLength(30);
        RuleFor(r => r.Email).NotEmpty().NotNull()
          .Must(r =>
          {
              Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
              var result = regex.Match(r);
              return result.Success;
          })
              .WithMessage("Please enter valid email");
        RuleFor(r => r.UserName).NotEmpty().NotNull().MinimumLength(3).MaximumLength(45);
        RuleFor(r => r.Password).NotEmpty().NotNull().MinimumLength(6);
        RuleFor(r => r).Must(u => u.Password == u.RepeatPassword)
            .WithMessage("Password must be equal to RepeatPassword");
    }
}
