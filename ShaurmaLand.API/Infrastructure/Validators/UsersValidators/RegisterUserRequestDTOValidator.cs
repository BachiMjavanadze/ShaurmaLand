using FluentValidation;
using ShaurmaLand.Application.Services.Users.Requests;

namespace ShaurmaLand.API.Infrastructure.Validators.UsersValidators;

public class RegisterUserRequestDTOValidator : AbstractValidator<RegisterUserRequestDTO>
{
    public RegisterUserRequestDTOValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .Length(2, 20)
            .WithMessage("Firstname should not be empty and must be between 2 and 20 characters.");

        RuleFor(x => x.LastName)
            .NotEmpty()
            .Length(2, 30)
            .WithMessage("Lastname should not be empty and must be between 2 and 30 characters.");

        RuleFor(x => x.Email)
            .NotEmpty()
            .Matches(@"^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$")
            .WithMessage("Email should not be empty and must be valid email format.");

        RuleFor(x => x.PhoneNumber)
            .NotEmpty()
            .Matches(@"^\d{10}$")
            .WithMessage("PhoneNumber should not be empty and must be a valid 10 digit phone number.");
    }
}

