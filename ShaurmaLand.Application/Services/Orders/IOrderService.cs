using ShaurmaLand.Application.Services.Orders.Requests;
using ShaurmaLand.Application.Services.Orders.Responses;

namespace ShaurmaLand.Application.Services.Orders;

public interface IOrderService
{
    Task<List<OrderResponseDTO>> GetAllAsync(CancellationToken cancellationToken);
    Task<OrderResponseDTO> GetAsync(int id, CancellationToken cancellationToken);
    Task<int> CreateAsync(CreateOrderRequestDTO order, CancellationToken cancellationToken);
    Task<bool> UserHasRightToOrder(int userId, int addressId, CancellationToken cancellationToken);
}
