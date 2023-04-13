using ShaurmaLand.Application.Services.Users.Requests;
using ShaurmaLand.Application.Services.Users.Responses;

namespace ShaurmaLand.Application.Services.Users;

public interface IUserService
{
    Task<List<UserResponseDTO>> GetAllAsync(CancellationToken cancellationToken);
    Task<UserResponseDTO> GetAsync(int id, CancellationToken cancellationToken);
    Task<int> CreateAsync(RegisterUserRequestDTO user, CancellationToken cancellationToken);
    Task UpdateAsync(int id, UpdateUserRequestDTO user, CancellationToken cancellationToken);
    Task<bool> DeleteAsync(int id, CancellationToken cancellationToken);
}
