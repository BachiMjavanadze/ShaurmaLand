namespace ShaurmaLand.Application.Exceptions.UserExceptions;

public class UserUnsuccessfulUpdateException : Exception
{
    public string Code = "UserUnsuccessfulUpdateException";
    public UserUnsuccessfulUpdateException(string errorText) : base(errorText) { }
}
