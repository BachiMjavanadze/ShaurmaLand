using Newtonsoft.Json;

namespace ShaurmaLand.API.Infrastructure.ErrorHandling;
public class GlobalExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<GlobalExceptionHandlerMiddleware> _logger;

    public GlobalExceptionHandlerMiddleware(RequestDelegate next, ILogger<GlobalExceptionHandlerMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
        ApiError error = new(context, ex);
        var result = JsonConvert.SerializeObject(error);

        context.Response.Clear();
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = error.Status.Value;

        _logger.LogInformation(result);

        await context.Response.WriteAsync(result);
    }
}