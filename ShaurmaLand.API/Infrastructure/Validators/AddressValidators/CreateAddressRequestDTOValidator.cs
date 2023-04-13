using FluentValidation;
using ShaurmaLand.Application.Services.Addresses.Requests;

namespace ShaurmaLand.API.Infrastructure.Validators.AddressValidators;

public class CreateAddressRequestDTOValidator : AbstractValidator<CreateAddressRequestDTO>
{
    public CreateAddressRequestDTOValidator()
    {
        RuleFor(x => x.City)
          .NotEmpty()
          .WithMessage("City is required")
          .Length(0, 15)
          .WithMessage("City name length should be between 1 and 15");

        RuleFor(x => x.Country)
          .NotEmpty()
          .WithMessage("Country is required")
          .Length(0, 15)
          .WithMessage("Country name length should be between 1 and 15");

        RuleFor(x => x.Region)
          .Length(0, 15)
          .WithMessage("Region name should be less than or equal to 15 characters");

        RuleFor(x => x.Description)
          .Length(0, 100)
          .WithMessage("Description should be less than or equal to 100 characters");
    }
}

