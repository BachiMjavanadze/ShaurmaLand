namespace ShaurmaLand.Application.Services.Orders.Responses;

public class OrderResponseDTO
{
    public int Id { get; set; }
    public int UserId { get; set; } // FK is User.Id
    public int AddressId { get; set; } // FK is Addrss.Id
}
