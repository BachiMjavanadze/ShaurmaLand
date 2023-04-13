using ShaurmaLand.Application.Services.Orders.Responses;
using Swashbuckle.AspNetCore.Filters;

namespace ShaurmaLand.API.SwaggerSettings.Examples.OrdersExamples;

public class GetAllOrdersResponseDTOExample : IExamplesProvider<OrderResponseDTO[]>
{
    public OrderResponseDTO[] GetExamples()
    {
        return new OrderResponseDTO[]
        {
            new OrderResponseDTO
            {
                Id = 1,
                UserId = 1,
                AddressId = 2,
            },
            new OrderResponseDTO
            {
                Id = 2,
                UserId = 4,
                AddressId = 8,
            }
        };
    }
}
