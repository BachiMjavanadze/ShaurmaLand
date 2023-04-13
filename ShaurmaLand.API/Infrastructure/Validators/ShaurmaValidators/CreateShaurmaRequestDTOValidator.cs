using FluentValidation;
using ShaurmaLand.Application.Services.Shaurmas.Requests;

namespace ShaurmaLand.API.Infrastructure.Validators.ShaurmaValidators;

public class CreateShaurmaRequestDTOValidator : AbstractValidator<CreateShaurmaRequestDTO>
{
    public CreateShaurmaRequestDTOValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .Length(3, 20)
            .WithMessage("Name should not be empty and must be between 3 and 20 characters.");

        RuleFor(x => x.Price)
            .NotEmpty()
            .GreaterThan(0)
            .WithMessage("Price should not be empty and should be greater than 0.");

        RuleFor(x => x.Description)
            .MaximumLength(100)
            .WithMessage("Description should not be more than 100 characters.");

        RuleFor(x => x.CaloryCount)
            .NotEmpty()
            .GreaterThan(0)
            .WithMessage("Calory count should be greater than 0.");
    }
}
