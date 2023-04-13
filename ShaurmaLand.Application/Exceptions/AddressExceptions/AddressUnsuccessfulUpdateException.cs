namespace ShaurmaLand.Application.Exceptions.AddressExceptions;

public class AddressUnsuccessfulUpdateException : Exception
{
    public string Code = "AddressUnsuccessfulUpdateException";
    public AddressUnsuccessfulUpdateException(string errorText) : base(errorText) { }
}
