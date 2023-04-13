using Mapster;
using Microsoft.Extensions.DependencyInjection;
using ShaurmaLand.Application.Services.Addresses.Requests;
using ShaurmaLand.Application.Services.Addresses.Responses;
using ShaurmaLand.Application.Services.Orders.Requests;
using ShaurmaLand.Application.Services.Orders.Responses;
using ShaurmaLand.Application.Services.Shaurmas.Requests;
using ShaurmaLand.Application.Services.Shaurmas.Responses;
using ShaurmaLand.Application.Services.Users.Requests;
using ShaurmaLand.Application.Services.Users.Responses;
using ShaurmaLand.Domain.Models;

namespace ShaurmaLand.Application.Mapper;

public static class MapperConfig
{
    public static void RegisterMaps(this IServiceCollection services)
    {
        TypeAdapterConfig<RegisterUserRequestDTO, User>.NewConfig();
        TypeAdapterConfig<UpdateUserRequestDTO, User>.NewConfig();
        TypeAdapterConfig<User, UserResponseDTO>.NewConfig();

        TypeAdapterConfig<CreateAddressRequestDTO, Address>.NewConfig();
        TypeAdapterConfig<UpdateAddressRequestDTO, Address>.NewConfig();
        TypeAdapterConfig<Address, AddressResponseDTO>.NewConfig();

        TypeAdapterConfig<CreateOrderRequestDTO, Order>.NewConfig();
        TypeAdapterConfig<Order, OrderResponseDTO>.NewConfig();
        TypeAdapterConfig<OrderResponseDTO, Order>.NewConfig();

        TypeAdapterConfig<Shaurma, ShaurmaResponseDTO>.NewConfig();
        TypeAdapterConfig<CreateShaurmaRequestDTO, Shaurma>.NewConfig();
    }
}
