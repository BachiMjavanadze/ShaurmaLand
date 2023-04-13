using ShaurmaLand.Infrastructure.Repositories.Addresses;
using ShaurmaLand.Infrastructure.Repositories.Orders;
using ShaurmaLand.Infrastructure.Repositories.Shaurmas;
using ShaurmaLand.Infrastructure.Repositories.Users;

namespace ShaurmaLand.Infrastructure;

public interface IUnitOfWork
{
    IUserRepository UserRepository { get; }
    IAddressRepository AddressRepository { get; }
    IOrderRepository OrderRepository { get; }
    IShaurmaRepository ShaurmaRepository { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
