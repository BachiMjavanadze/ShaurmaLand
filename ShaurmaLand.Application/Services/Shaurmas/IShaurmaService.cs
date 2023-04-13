using ShaurmaLand.Application.Services.Shaurmas.Requests;
using ShaurmaLand.Application.Services.Shaurmas.Responses;

namespace ShaurmaLand.Application.Services.Shaurmas;

public interface IShaurmaService
{
    Task<List<ShaurmaResponseDTO>> GetAllAsync(CancellationToken cancellationToken);
    Task<ShaurmaResponseDTO> GetAsync(int id, CancellationToken cancellationToken);
    Task<int> CreateAsync(CreateShaurmaRequestDTO pizza, CancellationToken cancellationToken);
    Task UpdateAsync(int id, UpdateShaurmaRequestDTO pizza, CancellationToken cancellationToken);
    Task<bool> DeleteAsync(int id, CancellationToken cancellationToken);
}
