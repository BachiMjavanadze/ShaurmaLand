namespace ShaurmaLand.Application.Exceptions.UserExceptions;

public class UserNotFoundException : Exception
{
    public string Code = "UserNotFoundException";
    public UserNotFoundException(string errorText) : base(errorText) { }
}
