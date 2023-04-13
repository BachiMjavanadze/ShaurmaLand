using ShaurmaLand.Application.Services.Orders.Responses;
using Swashbuckle.AspNetCore.Filters;

namespace ShaurmaLand.API.SwaggerSettings.Examples.OrdersExamples;

public class OrderResponseDTOExample : IExamplesProvider<OrderResponseDTO>
{
    public OrderResponseDTO GetExamples()
    {
        return new OrderResponseDTO
        {
            Id = 1,
            UserId = 1,
            AddressId = 2,
        };
    }
}
