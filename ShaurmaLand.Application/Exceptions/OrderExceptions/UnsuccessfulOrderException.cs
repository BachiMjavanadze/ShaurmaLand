namespace ShaurmaLand.Application.Exceptions.OrderExceptions;

public class UnsuccessfulOrderException : Exception
{
    public string Code = "UnsuccessfulOrderException";
    public UnsuccessfulOrderException(string errorText) : base(errorText) { }
}
