using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShaurmaLand.Domain.Models;

namespace ShaurmaLand.Persistence.Configuration;
public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> orderBuilder)
    {
        orderBuilder.HasKey(order => order.Id);

        orderBuilder.HasOne<Address>()
                    .WithMany()
                    .HasForeignKey(order => order.AddressId)
                    .OnDelete(DeleteBehavior.NoAction);

        orderBuilder.HasMany(order => order.Shaurmas)
                    .WithMany(pizza => pizza.Orders)
                    .UsingEntity(op => op.ToTable("OrderShaurma"));
    }
}
