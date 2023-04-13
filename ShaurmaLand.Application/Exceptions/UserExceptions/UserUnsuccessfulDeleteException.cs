namespace ShaurmaLand.Application.Exceptions.UserExceptions;

public class UserUnsuccessfulDeleteException : Exception
{
    public string Code = "UserUnsuccessfulDeleteException";
    public UserUnsuccessfulDeleteException(string errorText) : base(errorText) { }
}
