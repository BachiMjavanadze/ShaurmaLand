using ShaurmaLand.Domain.Models;

namespace ShaurmaLand.Infrastructure.Repositories.Shaurmas;

public interface IShaurmaRepository
{
    Task<List<Shaurma>> GetAllAsync(CancellationToken cancellationToken);
    Task<Shaurma> GetAsync(int id, CancellationToken cancellationToken);
    Task CreateAsync(Shaurma shaurma, CancellationToken cancellationToken);
    Task UpdateAsync(Shaurma shaurma, int id, CancellationToken cancellationToken);
    Task DeleteAsync(int id, CancellationToken cancellationToken);
}
