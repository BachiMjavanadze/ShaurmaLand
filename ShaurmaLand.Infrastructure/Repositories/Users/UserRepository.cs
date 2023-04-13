using Microsoft.EntityFrameworkCore;
using ShaurmaLand.Domain.Models;
using ShaurmaLand.Persistence.DAL;

namespace ShaurmaLand.Infrastructure.Repositories.Users;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _dbContext;

    public UserRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<User>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _dbContext.Users
            .Where(u => u.IsDeleted == false)
            .Include(a => a.Addresses.Where(a => a.IsDeleted == false))
            .Include(o => o.Orders.Where(a => a.IsDeleted == false))
            .ToListAsync(cancellationToken);
    }

    public async Task<User> GetAsync(int id, CancellationToken cancellationToken)
    {
        return await _dbContext.Users
            .Include(a => a.Addresses.Where(a => a.IsDeleted == false))
            .Include(o => o.Orders.Where(o => o.IsDeleted == false))
            .SingleOrDefaultAsync(u => u.Id == id && u.IsDeleted == false, cancellationToken);
    }

    public async Task CreateAsync(User user, CancellationToken cancellationToken)
    {
        await _dbContext.Users.AddAsync(user, cancellationToken);
    }

    public async Task UpdateAsync(User user, int id, CancellationToken cancellationToken)
    {
        await _dbContext.Users
            .Where(u => u.Id == id && u.IsDeleted == false)
            .ExecuteUpdateAsync(oldUser => oldUser
                .SetProperty(oldUser => oldUser.Name, user.Name)
                .SetProperty(oldUser => oldUser.LastName, user.LastName)
                .SetProperty(oldUser => oldUser.Email, user.Email)
                .SetProperty(oldUser => oldUser.PhoneNumber, user.PhoneNumber)
                .SetProperty(oldUser => oldUser.ModifiedOn, DateTime.UtcNow),
            cancellationToken);
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken)
    {
        var user = await GetAsync(id, cancellationToken);
        user.IsDeleted = true;
        _dbContext.Users.Update(user);
    }
}
