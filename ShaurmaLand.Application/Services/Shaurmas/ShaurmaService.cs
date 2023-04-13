using Mapster;
using ShaurmaLand.Application.Exceptions.ShaurmaExceptions;
using ShaurmaLand.Application.Services.Shaurmas.Requests;
using ShaurmaLand.Application.Services.Shaurmas.Responses;
using ShaurmaLand.Domain.Models;
using ShaurmaLand.Infrastructure;

namespace ShaurmaLand.Application.Services.Shaurmas;
public class ShaurmaService : IShaurmaService
{
    private readonly IUnitOfWork _unitOfWork;

    public ShaurmaService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<ShaurmaResponseDTO>> GetAllAsync(CancellationToken cancellationToken)
    {
        var shaurmas = await _unitOfWork.ShaurmaRepository.GetAllAsync(cancellationToken);
        return shaurmas.Adapt<List<ShaurmaResponseDTO>>();
    }

    public async Task<ShaurmaResponseDTO> GetAsync(int id, CancellationToken cancellationToken)
    {
        var shaurma = await _unitOfWork.ShaurmaRepository.GetAsync(id, cancellationToken);
        if (shaurma == null)
        {
            throw new ShaurmaNotFoundException("ShaurmaNotFoundException");
        }

        return shaurma.Adapt<ShaurmaResponseDTO>();
    }

    public async Task<int> CreateAsync(CreateShaurmaRequestDTO shaurmaDTO, CancellationToken cancellationToken)
    {
        if (shaurmaDTO == null)
        {
            throw new ArgumentNullException();
        }

        var currentShaurma = shaurmaDTO.Adapt<Shaurma>();
        await _unitOfWork.ShaurmaRepository.CreateAsync(currentShaurma, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return currentShaurma.Id;
    }

    public async Task UpdateAsync(int id, UpdateShaurmaRequestDTO shaurmaDTO, CancellationToken cancellationToken)
    {
        var oldShaurma = await _unitOfWork.ShaurmaRepository.GetAsync(id, cancellationToken);
        if (oldShaurma == null)
        {
            throw new ShaurmaNotFoundException("ShaurmaNotFoundException");
        }
        if (shaurmaDTO == null)
        {
            throw new ShaurmaUnsuccessfulUpdateException("ShaurmaUnsuccessfulUpdateException");
        }
        var currentShaurma = shaurmaDTO.Adapt<Shaurma>();
        await _unitOfWork.ShaurmaRepository.UpdateAsync(currentShaurma, id, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken)
    {
        var shaurma = await _unitOfWork.ShaurmaRepository.GetAsync(id, cancellationToken);
        if (shaurma == null)
        {
            throw new ShaurmaUnsuccessfulDeleteException("ShaurmaUnsuccessfulDeleteException");
        }
        await _unitOfWork.ShaurmaRepository.DeleteAsync(id, cancellationToken);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0;
    }
}
