namespace ShaurmaLand.Application.Exceptions.OrderExceptions;

public class OrderNotFoundException : Exception
{
    public string Code = "OrderNotFoundException";
    public OrderNotFoundException(string errorText) : base(errorText) { }
}
