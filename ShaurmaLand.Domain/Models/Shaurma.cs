namespace ShaurmaLand.Domain.Models;
public class Shaurma
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public string Description { get; set; }
    public double CaloryCount { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
    public DateTime ModifiedOn { get; set; } = DateTime.UtcNow;
    public List<Order> Orders { get; set; }
}
