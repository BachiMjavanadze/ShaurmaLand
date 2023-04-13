namespace ShaurmaLand.Domain.Models;

public class Address
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public string Region { get; set; }
    public string Description { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
    public DateTime ModifiedOn { get; set; } = DateTime.UtcNow;
    public List<Order> Orders { get; set; }
}
