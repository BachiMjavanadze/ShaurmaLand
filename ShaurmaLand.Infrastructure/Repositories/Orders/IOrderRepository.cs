using ShaurmaLand.Domain.Models;

namespace ShaurmaLand.Infrastructure.Repositories.Orders;

public interface IOrderRepository
{
    Task<List<Order>> GetAllAsync(CancellationToken cancellationToken);
    Task<Order> GetAsync(int id, CancellationToken cancellationToken);
    Task CreateAsync(Order order, CancellationToken cancellationToken);
    Task DeleteManyAsync(int userId, CancellationToken cancellationToken);
}
