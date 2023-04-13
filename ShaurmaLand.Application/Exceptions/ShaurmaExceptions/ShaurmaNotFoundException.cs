namespace ShaurmaLand.Application.Exceptions.ShaurmaExceptions;

public class ShaurmaNotFoundException : Exception
{
    public string Code = "ShaurmaNotFoundException";
    public ShaurmaNotFoundException(string errorText) : base(errorText) { }
}
