namespace ShaurmaLand.Application.Exceptions.AddressExceptions;

public class AddressNotFoundException : Exception
{
    public string Code = "AddressNotFoundException";
    public AddressNotFoundException(string errorText) : base(errorText) { }
}
