﻿using FluentValidation;
using TimeZone.Core.Entities;

namespace TimeZone.Business.Dtos.UserDtos;

public class LoginDto
{
    public string UserName { get; set; }
    public string Password { get; set; }
}
public class LoginDtoValidator : AbstractValidator<LoginDto>
{
    public LoginDtoValidator()
    {
        RuleFor(l => l.UserName).NotEmpty().NotNull().MinimumLength(3).MaximumLength(45);
        RuleFor(l => l.Password).NotEmpty().NotNull().MinimumLength(6);
    }
}