using Mapster;
using ShaurmaLand.Application.Exceptions.OrderExceptions;
using ShaurmaLand.Application.Exceptions.ShaurmaExceptions;
using ShaurmaLand.Application.Exceptions.UserExceptions;
using ShaurmaLand.Application.Services.Orders.Requests;
using ShaurmaLand.Application.Services.Orders.Responses;
using ShaurmaLand.Domain.Models;
using ShaurmaLand.Infrastructure;

namespace ShaurmaLand.Application.Services.Orders;

public class OrderService : IOrderService
{
    private readonly IUnitOfWork _unitOfWork;

    public OrderService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<OrderResponseDTO>> GetAllAsync(CancellationToken cancellationToken)
    {
        var orders = await _unitOfWork.OrderRepository.GetAllAsync(cancellationToken);
        if (orders == null)
        {
            throw new OrderNotFoundException("Orders were not found.");
        }

        var shaurmaIds = orders.SelectMany(o => o.Shaurmas.Select(p => p.Id));
        var shaurmas = await _unitOfWork.ShaurmaRepository.GetAllAsync(cancellationToken);
        var selectedPizzas = shaurmas.Where(p => shaurmaIds.Contains(p.Id));

        foreach (var order in orders)
        {
            order.Shaurmas = shaurmas.Where(p => order.Shaurmas.Any(op => op.Id == p.Id)).ToList();
        }

        return orders.Adapt<List<OrderResponseDTO>>();
    }

    public async Task<OrderResponseDTO> GetAsync(int orderId, CancellationToken cancellationToken)
    {
        if (orderId == 0)
        {
            throw new InvalidDataException("Id can not be 0.");
        }

        var order = await _unitOfWork.OrderRepository.GetAsync(orderId, cancellationToken);
        if (order == null)
        {
            throw new OrderNotFoundException("Order was not found.");
        }

        var shaurmaIds = order.Shaurmas.Select(o => o.Id);
        var shaurmas = await _unitOfWork.ShaurmaRepository.GetAllAsync(cancellationToken);
        var selectedShaurmas = shaurmas.Where(p => shaurmaIds.Contains(p.Id)).ToList();
        order.Shaurmas = selectedShaurmas;

        return order.Adapt<OrderResponseDTO>();
    }

    public async Task<int> CreateAsync(CreateOrderRequestDTO orderDTO, CancellationToken cancellationToken = default)
    {
        if (orderDTO == null)
        {
            throw new ArgumentNullException(nameof(orderDTO), "ArgumentNullException");
        }

        if (await UserHasRightToOrder(orderDTO.UserId, orderDTO.AddressId, cancellationToken))
        {
            var shaurmas = await _unitOfWork.ShaurmaRepository.GetAllAsync(cancellationToken);
            var selectedShaurmas = shaurmas.Where(p => orderDTO.Shaurmas.Contains(p.Id)).ToList();

            if (selectedShaurmas.Any())
            {
                var order = orderDTO.Adapt<Order>();
                order.Shaurmas = selectedShaurmas;
                await _unitOfWork.OrderRepository.CreateAsync(order, cancellationToken);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return order.Id;
            }
            else
            {
                throw new ShaurmaNotFoundException("ShaurmaNotFoundException");
            }
        }

        return 0;
    }

    public async Task<bool> UserHasRightToOrder(int userId, int addressId, CancellationToken cancellationToken)
    {
        var user = await _unitOfWork.UserRepository.GetAsync(userId, cancellationToken);
        if (user == null)
        {
            throw new UserNotFoundException("UserNotFoundException");
        }
        bool addresses = user.Addresses.Any(a => a.Id == addressId);
        if (!addresses)
        {
            throw new UnsuccessfulOrderException("The user has no rights to order to this address.");
        }

        return true;
    }
}
