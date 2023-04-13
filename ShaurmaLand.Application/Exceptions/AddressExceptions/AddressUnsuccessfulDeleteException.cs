namespace ShaurmaLand.Application.Exceptions.AddressExceptions;

public class AddressUnsuccessfulDeleteException : Exception
{
    public string Code = "AddressUnsuccessfulDeleteException";
    public AddressUnsuccessfulDeleteException(string errorText) : base(errorText) { }
}
