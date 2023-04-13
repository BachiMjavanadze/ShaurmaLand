namespace ShaurmaLand.Domain.Models;
public class Order
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int AddressId { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
    public DateTime ModifiedOn { get; set; } = DateTime.UtcNow;
    public List<Shaurma> Shaurmas { get; set; }
}
