using System;
using Application.DTO;
using Application.Enums;
using FluentValidation;

namespace Application.Validators;

public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
{
    public RegisterRequestValidator()
    {
        RuleFor(x=>x.Email).NotEmpty().EmailAddress();
        RuleFor(x=>x.Password).NotEmpty().WithMessage("Password is required");
        RuleFor(x=>x.Gender)
        .Must(g => Enum.TryParse<GenderOptions>(g,true,out _))
        .WithMessage("Invalid gender. Allowed values are Male, Female, Other.");
    }
}
