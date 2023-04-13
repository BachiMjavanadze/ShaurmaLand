namespace ShaurmaLand.Application.Exceptions.ShaurmaExceptions;

public class ShaurmaUnsuccessfulDeleteException : Exception
{
    public string Code = "ShaurmaUnsuccessfulDeleteException";
    public ShaurmaUnsuccessfulDeleteException(string errorText) : base(errorText) { }
}
