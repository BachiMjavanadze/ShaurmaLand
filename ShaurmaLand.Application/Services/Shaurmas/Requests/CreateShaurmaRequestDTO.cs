namespace ShaurmaLand.Application.Services.Shaurmas.Requests;

public class CreateShaurmaRequestDTO
{
    public string Name { get; set; }
    public double Price { get; set; }
    public string Description { get; set; }
    public double CaloryCount { get; set; }
}
