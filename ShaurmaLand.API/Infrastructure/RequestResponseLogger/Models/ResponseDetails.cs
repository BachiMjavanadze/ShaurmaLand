namespace ShaurmaLand.API.Infrastructure.RequestResponseLogger.Models;

public class ResponseDetails
{
    public string Body { get; set; }
    public DateTime ResponseTime => DateTime.UtcNow;
}
