using ShaurmaLand.Infrastructure.Repositories.Addresses;
using ShaurmaLand.Infrastructure.Repositories.Orders;
using ShaurmaLand.Infrastructure.Repositories.Shaurmas;
using ShaurmaLand.Infrastructure.Repositories.Users;
using ShaurmaLand.Persistence.DAL;

namespace ShaurmaLand.Infrastructure;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly ApplicationDbContext _context;

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;

        UserRepository = new UserRepository(context);
        AddressRepository = new AddressRepository(context);
        OrderRepository = new OrderRepository(context);
        ShaurmaRepository = new ShaurmaRepository(context);
    }

    public IUserRepository UserRepository { get; set; }
    public IAddressRepository AddressRepository { get; set; }
    public IOrderRepository OrderRepository { get; set; }
    public IShaurmaRepository ShaurmaRepository { get; set; }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
