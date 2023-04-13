using Microsoft.EntityFrameworkCore;
using ShaurmaLand.Domain.Models;
using ShaurmaLand.Persistence.DAL;

namespace ShaurmaLand.Infrastructure.Repositories.Addresses;

public class AddressRepository : IAddressRepository
{
    private readonly ApplicationDbContext _dbContext;

    public AddressRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Address>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _dbContext.Addresses
            .Where(a => a.IsDeleted == false)
            .ToListAsync(cancellationToken);
    }

    public async Task<Address> GetAsync(int id, CancellationToken cancellationToken)
    {
        return await _dbContext.Addresses
            .SingleOrDefaultAsync(a => a.Id == id && a.IsDeleted == false,
            cancellationToken);
    }

    public async Task CreateAsync(Address address, CancellationToken cancellationToken)
    {
        await _dbContext.Addresses.AddAsync(address, cancellationToken);
    }

    public async Task UpdateAsync(Address address, int id, CancellationToken cancellationToken)
    {
        await _dbContext.Addresses
            .Where(a => a.Id == id && a.IsDeleted == false)
            .ExecuteUpdateAsync(oldAddress => oldAddress
                .SetProperty(oldAddress => oldAddress.City, address.City)
                .SetProperty(oldAddress => oldAddress.Country, address.Country)
                .SetProperty(oldAddress => oldAddress.Region, address.Region)
                .SetProperty(oldAddress => oldAddress.Description, address.Description)
                .SetProperty(oldAddress => oldAddress.ModifiedOn, DateTime.UtcNow),
            cancellationToken);
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken)
    {
        var address = await GetAsync(id, cancellationToken);
        address.IsDeleted = true;
        _dbContext.Addresses.Update(address);
    }

    public async Task DeleteManyAsync(int id, CancellationToken cancellationToken)
    {
        await _dbContext.Addresses
            .Where(a => a.UserId == id && a.IsDeleted == false)
            .ExecuteUpdateAsync(oldAddress => oldAddress
                .SetProperty(oldAddress => oldAddress.IsDeleted, true)
                .SetProperty(oldAddress => oldAddress.ModifiedOn, DateTime.UtcNow),
            cancellationToken);
    }
}
