using ShaurmaLand.Application.Services.Addresses.Requests;
using ShaurmaLand.Application.Services.Addresses.Responses;

namespace ShaurmaLand.Application.Services.Addresses;

public interface IAddressService
{
    Task<List<AddressResponseDTO>> GetAllAsync(CancellationToken cancellationToken);
    Task<AddressResponseDTO> GetAsync(int id, CancellationToken cancellationToken);
    Task<int> CreateAsync(CreateAddressRequestDTO address, CancellationToken cancellationToken);
    Task<bool> UpdateAsync(int id, UpdateAddressRequestDTO address, CancellationToken cancellationToken);
    Task<bool> DeleteAsync(int id, CancellationToken cancellationToken);
}
