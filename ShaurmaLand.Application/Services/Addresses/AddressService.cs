using Mapster;
using ShaurmaLand.Application.Exceptions.AddressExceptions;
using ShaurmaLand.Application.Exceptions.UserExceptions;
using ShaurmaLand.Application.Services.Addresses.Requests;
using ShaurmaLand.Application.Services.Addresses.Responses;
using ShaurmaLand.Domain.Models;
using ShaurmaLand.Infrastructure;

namespace ShaurmaLand.Application.Services.Addresses;

public class AddressService : IAddressService
{
    private readonly IUnitOfWork _unitOfWork;

    public AddressService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<AddressResponseDTO>> GetAllAsync(CancellationToken cancellationToken)
    {
        var addresses = await _unitOfWork.AddressRepository.GetAllAsync(cancellationToken);
        return addresses.Adapt<List<AddressResponseDTO>>();
    }

    public async Task<AddressResponseDTO> GetAsync(int id, CancellationToken cancellationToken)
    {
        var address = await _unitOfWork.AddressRepository.GetAsync(id, cancellationToken);
        if (address == null)
        {
            throw new AddressNotFoundException("AddressNotFoundException");
        }

        return address.Adapt<AddressResponseDTO>();
    }

    public async Task<int> CreateAsync(CreateAddressRequestDTO addressDTO, CancellationToken cancellationToken)
    {
        if (addressDTO == null)
        {
            throw new ArgumentNullException(nameof(addressDTO), "AddressNullException");
        }
        var user = await _unitOfWork.UserRepository.GetAsync(addressDTO.UserId, cancellationToken);
        if (user == null)
        {
            throw new UserNotFoundException("UserNotFoundException");
        }
        var currentAddress = addressDTO.Adapt<Address>();
        await _unitOfWork.AddressRepository.CreateAsync(currentAddress, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return currentAddress.Id;
    }

    public async Task<bool> UpdateAsync(int id, UpdateAddressRequestDTO addressDTO, CancellationToken cancellationToken)
    {
        var oldAddress = await _unitOfWork.AddressRepository.GetAsync(id, cancellationToken);
        if (oldAddress == null)
        {
            throw new AddressNotFoundException("AddressNotFoundException");
        }
        if (addressDTO == null)
        {
            throw new AddressUnsuccessfulDeleteException("AddressUnsuccessfulDeleteException");
        }
        var currentAddress = addressDTO.Adapt<Address>();
        await _unitOfWork.AddressRepository.UpdateAsync(currentAddress, id, cancellationToken);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
        if (result <= 0)
        {
            return false;
        }

        return true;
    }

    public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken)
    {
        var address = await _unitOfWork.AddressRepository.GetAsync(id, cancellationToken);
        if (address == null)
        {
            throw new AddressUnsuccessfulDeleteException("AddressUnsuccessfulDeleteException");
        }

        await _unitOfWork.AddressRepository.DeleteAsync(id, cancellationToken);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0;
    }
}
