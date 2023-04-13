using ShaurmaLand.Domain.Models;

namespace ShaurmaLand.Infrastructure.Repositories.Addresses;

public interface IAddressRepository
{
    Task<List<Address>> GetAllAsync(CancellationToken cancellationToken);
    Task<Address> GetAsync(int id, CancellationToken cancellationToken);
    Task CreateAsync(Address address, CancellationToken cancellationToken);
    Task UpdateAsync(Address address, int id, CancellationToken cancellationToken);
    Task DeleteAsync(int id, CancellationToken cancellationToken);
    Task DeleteManyAsync(int id, CancellationToken cancellationToken);
}
