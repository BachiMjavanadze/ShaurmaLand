using System.Net;
using Microsoft.AspNetCore.Mvc;
using ShaurmaLand.Application.Exceptions.AddressExceptions;
using ShaurmaLand.Application.Exceptions.OrderExceptions;
using ShaurmaLand.Application.Exceptions.ShaurmaExceptions;
using ShaurmaLand.Application.Exceptions.UserExceptions;
using ShaurmaLand.Shared.Localizations;

namespace ShaurmaLand.API.Infrastructure.ErrorHandling;
public class ApiError : ProblemDetails
{
    public const string UnhandlerErrorCode = "UnhandledError";
    private HttpContext _httpContext;
    private Exception _exception;
    public LogLevel LogLevel { get; set; }
    public string Code { get; set; }

    public ApiError(HttpContext httpContext, Exception exception)
    {
        _httpContext = httpContext;
        _exception = exception;

        TraceId = httpContext.TraceIdentifier;

        //default
        Code = UnhandlerErrorCode;
        Status = (int)HttpStatusCode.InternalServerError;
        Title = exception.Message;
        LogLevel = LogLevel.Error;
        Instance = httpContext.Request.Path;

        HandleException((dynamic)exception);
    }

    public string TraceId
    {
        get
        {
            if (Extensions.TryGetValue("TraceId", out var traceId))
            {
                return (string)traceId;
            }

            return null;
        }

        set => Extensions["TraceId"] = value;
    }

    #region Users Exceptions
    private void HandleException(UserNotFoundException exception)
    {
        Code = exception.Code;
        Status = (int)HttpStatusCode.NotFound;
        Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.4";
        Title = ErrorMessages.UserNotFoundException;
        LogLevel = LogLevel.Information;
    }

    private void HandleException(UserUnsuccessfulUpdateException exception)
    {
        Code = exception.Code;
        Status = (int)HttpStatusCode.BadRequest;
        Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.1";
        Title = ErrorMessages.UserUnsuccessfulUpdateException;
        LogLevel = LogLevel.Information;
    }

    private void HandleException(UserUnsuccessfulDeleteException exception)
    {
        Code = exception.Code;
        Status = (int)HttpStatusCode.BadRequest;
        Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.1";
        Title = ErrorMessages.UserUnsuccessfulDeleteException;
        LogLevel = LogLevel.Information;
    }
    #endregion

    #region Addresses Exceptions
    private void HandleException(AddressNotFoundException exception)
    {
        Code = exception.Code;
        Status = (int)HttpStatusCode.NotFound;
        Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.4";
        Title = ErrorMessages.AddressNotFoundException;
        LogLevel = LogLevel.Information;
    }

    private void HandleException(AddressUnsuccessfulUpdateException exception)
    {
        Code = exception.Code;
        Status = (int)HttpStatusCode.BadRequest;
        Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.1";
        Title = ErrorMessages.AddressUnsuccessfulUpdateException;
        LogLevel = LogLevel.Information;
    }

    private void HandleException(AddressUnsuccessfulDeleteException exception)
    {
        Code = exception.Code;
        Status = (int)HttpStatusCode.BadRequest;
        Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.1";
        Title = ErrorMessages.AddressUnsuccessfulDeleteException;
        LogLevel = LogLevel.Information;
    }
    #endregion

    #region Pizzas Exceptions
    private void HandleException(ShaurmaNotFoundException exception)
    {
        Code = exception.Code;
        Status = (int)HttpStatusCode.NotFound;
        Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.4";
        Title = ErrorMessages.ShaurmaNotFoundException;
        LogLevel = LogLevel.Information;
    }

    private void HandleException(ShaurmaUnsuccessfulUpdateException exception)
    {
        Code = exception.Code;
        Status = (int)HttpStatusCode.BadRequest;
        Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.1";
        Title = ErrorMessages.ShaurmaUnsuccessfulUpdateException;
        LogLevel = LogLevel.Information;
    }

    private void HandleException(ShaurmaUnsuccessfulDeleteException exception)
    {
        Code = exception.Code;
        Status = (int)HttpStatusCode.BadRequest;
        Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.1";
        Title = ErrorMessages.ShaurmaUnsuccessfulDeleteException;
        LogLevel = LogLevel.Information;
    }
    #endregion

    #region Orders Exceptions
    private void HandleException(OrderNotFoundException exception)
    {
        Code = exception.Code;
        Status = (int)HttpStatusCode.NotFound;
        Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.4";
        Title = ErrorMessages.OrderNotFoundException;
        LogLevel = LogLevel.Information;
    }
    private void HandleException(UnsuccessfulOrderException exception)
    {
        Code = exception.Code;
        Status = (int)HttpStatusCode.NotFound;
        Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.4";
        Title = ErrorMessages.UnsuccessfulOrderException;
        LogLevel = LogLevel.Information;
    }
    #endregion

    private void HandleException(ArgumentNullException exception)
    {
        Code = "ArgumentNullException";
        Status = (int)HttpStatusCode.BadRequest;
        Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.1";
        Title = ErrorMessages.ArgumentNullException;
        LogLevel = LogLevel.Information;
    }

    private void HandleException(Exception exception) { }
}
