using FluentValidation;
using ShaurmaLand.Application.Services.Orders.Requests;

namespace ShaurmaLand.API.Infrastructure.Validators.OrderValidators;

public class OrderValidator : AbstractValidator<CreateOrderRequestDTO>
{
    public OrderValidator()
    {
        RuleFor(x => x.Shaurmas)
            .NotEmpty()
            .WithMessage("List of Shaurmas should not be empty.");
    }
}
