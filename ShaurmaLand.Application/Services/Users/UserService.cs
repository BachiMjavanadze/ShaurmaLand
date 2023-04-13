using Mapster;
using ShaurmaLand.Application.Exceptions.UserExceptions;
using ShaurmaLand.Application.Services.Users.Requests;
using ShaurmaLand.Application.Services.Users.Responses;
using ShaurmaLand.Domain.Models;
using ShaurmaLand.Infrastructure;

namespace ShaurmaLand.Application.Services.Users;

public class UserService : IUserService
{
    private readonly IUnitOfWork _unitOfWork;

    public UserService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<UserResponseDTO>> GetAllAsync(CancellationToken cancellationToken)
    {
        var users = await _unitOfWork.UserRepository.GetAllAsync(cancellationToken);
        return users.Adapt<List<UserResponseDTO>>();
    }

    public async Task<UserResponseDTO> GetAsync(int id, CancellationToken cancellationToken)
    {
        var user = await _unitOfWork.UserRepository.GetAsync(id, cancellationToken);
        if (user == null)
        {
            throw new UserNotFoundException("UserNotFoundException");
        }

        return user.Adapt<UserResponseDTO>();
    }

    public async Task<int> CreateAsync(RegisterUserRequestDTO userDTO, CancellationToken cancellationToken)
    {
        if (userDTO == null)
        {
            throw new ArgumentNullException();
        }
        var currentUser = userDTO.Adapt<User>();
        await _unitOfWork.UserRepository.CreateAsync(currentUser, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return currentUser.Id;
    }

    public async Task UpdateAsync(int id, UpdateUserRequestDTO userDTO, CancellationToken cancellationToken)
    {
        var oldUser = await _unitOfWork.UserRepository.GetAsync(id, cancellationToken);
        if (oldUser == null)
        {
            throw new UserNotFoundException("UserNotFoundException");
        }
        if (userDTO == null)
        {
            throw new UserUnsuccessfulUpdateException("UserUnsuccessfulUpdateException");
        }
        var currentUser = userDTO.Adapt<User>();
        await _unitOfWork.UserRepository.UpdateAsync(currentUser, id, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken)
    {
        var user = await _unitOfWork.UserRepository.GetAsync(id, cancellationToken);
        if (user == null)
        {
            throw new UserUnsuccessfulDeleteException("UserUnsuccessfulDeleteException");
        }
        await _unitOfWork.UserRepository.DeleteAsync(id, cancellationToken);
        if (user.Addresses != null)
        {
            await _unitOfWork.AddressRepository.DeleteManyAsync(id, cancellationToken);
        }
        if (user.Orders != null)
        {
            await _unitOfWork.OrderRepository.DeleteManyAsync(id, cancellationToken);
        }
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0;
    }
}
