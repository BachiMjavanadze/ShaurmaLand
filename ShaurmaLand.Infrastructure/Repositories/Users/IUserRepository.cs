using ShaurmaLand.Domain.Models;

namespace ShaurmaLand.Infrastructure.Repositories.Users;

public interface IUserRepository
{
    Task<List<User>> GetAllAsync(CancellationToken cancellationToken);
    Task<User> GetAsync(int id, CancellationToken cancellationToken);
    Task CreateAsync(User user, CancellationToken cancellationToken);
    Task UpdateAsync(User user, int id, CancellationToken cancellationToken);
    Task DeleteAsync(int id, CancellationToken cancellationToken);
}
