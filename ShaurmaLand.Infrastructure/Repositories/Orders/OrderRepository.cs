using Microsoft.EntityFrameworkCore;
using ShaurmaLand.Domain.Models;
using ShaurmaLand.Persistence.DAL;

namespace ShaurmaLand.Infrastructure.Repositories.Orders;

public class OrderRepository : IOrderRepository
{
    private readonly ApplicationDbContext _dbContext;

    public OrderRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Order>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _dbContext.Orders
            .Where(o => o.IsDeleted == false)
            .Include(s => s.Shaurmas.Where(s => s.IsDeleted == false))
            .ToListAsync(cancellationToken);
    }

    public async Task<Order> GetAsync(int id, CancellationToken cancellationToken)
    {
        return await _dbContext.Orders
            .Include(s => s.Shaurmas.Where(s => s.IsDeleted == false))
            .SingleOrDefaultAsync(o => o.Id == id && o.IsDeleted == false,
            cancellationToken);
    }

    public async Task CreateAsync(Order order, CancellationToken cancellationToken)
    {
        await _dbContext.Orders.AddAsync(order, cancellationToken);
    }

    public async Task DeleteManyAsync(int userId, CancellationToken cancellationToken)
    {
        await _dbContext.Orders
            .Where(o => o.UserId == userId && o.IsDeleted == false)
            .ExecuteUpdateAsync(o => o
                .SetProperty(o => o.IsDeleted, true)
                .SetProperty(o => o.ModifiedOn, DateTime.UtcNow),
            cancellationToken);
    }
}
