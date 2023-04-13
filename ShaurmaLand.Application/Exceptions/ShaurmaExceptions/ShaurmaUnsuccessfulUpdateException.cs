namespace ShaurmaLand.Application.Exceptions.ShaurmaExceptions;

public class ShaurmaUnsuccessfulUpdateException : Exception
{
    public string Code = "ShaurmaUnsuccessfulUpdateException ";
    public ShaurmaUnsuccessfulUpdateException(string errorText) : base(errorText) { }
}
