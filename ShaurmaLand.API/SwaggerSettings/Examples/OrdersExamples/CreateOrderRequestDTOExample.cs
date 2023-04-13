using ShaurmaLand.Application.Services.Orders.Requests;
using Swashbuckle.AspNetCore.Filters;

namespace ShaurmaLand.API.SwaggerSettings.Examples.OrdersExamples;

public class CreateOrderRequestDTOExample : IExamplesProvider<CreateOrderRequestDTO>
{
    public CreateOrderRequestDTO GetExamples()
    {
        return new CreateOrderRequestDTO
        {
            UserId = 1,
            AddressId = 2,
            Shaurmas = new List<int> { 1, 2 }
        };
    }
}
