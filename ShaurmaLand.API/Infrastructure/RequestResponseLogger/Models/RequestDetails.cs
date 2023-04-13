namespace ShaurmaLand.API.Infrastructure.RequestResponseLogger.Models;

public class RequestDetails
{
    public string IP { get; set; }
    public string Schema { get; set; }
    public string Host { get; set; }
    public string Method { get; set; }
    public string Path { get; set; }
    public string QueryString { get; set; }
    public string Body { get; set; }
    public bool IsSecured { get; set; }
    public DateTime RequestTime => DateTime.UtcNow;
}
