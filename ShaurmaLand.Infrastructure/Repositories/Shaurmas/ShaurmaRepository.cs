using Microsoft.EntityFrameworkCore;
using ShaurmaLand.Domain.Models;
using ShaurmaLand.Persistence.DAL;

namespace ShaurmaLand.Infrastructure.Repositories.Shaurmas;

public class ShaurmaRepository : IShaurmaRepository
{
    private readonly ApplicationDbContext _dbContext;

    public ShaurmaRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Shaurma>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _dbContext.Shaurmas
            .Where(s => s.IsDeleted == false)
            .ToListAsync(cancellationToken);
    }

    public async Task<Shaurma> GetAsync(int id, CancellationToken cancellationToken)
    {
        return await _dbContext.Shaurmas
            .SingleOrDefaultAsync(s => s.Id == id && s.IsDeleted == false,
            cancellationToken);
    }

    public async Task CreateAsync(Shaurma shaurma, CancellationToken cancellationToken)
    {
        await _dbContext.Shaurmas.AddAsync(shaurma, cancellationToken);
    }

    public async Task UpdateAsync(Shaurma shaurma, int id, CancellationToken cancellationToken)
    {
        await _dbContext.Shaurmas
          .Where(p => p.Id == id && p.IsDeleted == false)
          .ExecuteUpdateAsync(oldShaurma => oldShaurma
              .SetProperty(oldShaurma => oldShaurma.Name, shaurma.Name)
              .SetProperty(oldShaurma => oldShaurma.Price, shaurma.Price)
              .SetProperty(oldShaurma => oldShaurma.Description, shaurma.Description)
              .SetProperty(oldShaurma => oldShaurma.CaloryCount, shaurma.CaloryCount)
              .SetProperty(oldShaurma => oldShaurma.ModifiedOn, DateTime.UtcNow),
           cancellationToken);
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken)
    {
        var shaurma = await GetAsync(id, cancellationToken);
        shaurma.IsDeleted = true;
        _dbContext.Shaurmas.Update(shaurma);
    }
}
