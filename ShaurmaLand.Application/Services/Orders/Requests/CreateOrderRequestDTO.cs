namespace ShaurmaLand.Application.Services.Orders.Requests;

public class CreateOrderRequestDTO
{
    public int UserId { get; set; }
    public int AddressId { get; set; }
    public List<int> Shaurmas { get; set; }
}
