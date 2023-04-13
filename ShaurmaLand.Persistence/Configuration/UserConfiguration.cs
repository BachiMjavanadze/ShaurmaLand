using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShaurmaLand.Domain.Models;

namespace ShaurmaLand.Persistence.Configuration;
public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> userBuilder)
    {
        userBuilder.HasKey(user => user.Id);

        userBuilder.HasMany(user => user.Orders)
                   .WithOne()
                   .HasForeignKey(order => order.UserId)
                   .OnDelete(DeleteBehavior.NoAction);

        userBuilder.HasMany(user => user.Addresses)
                   .WithOne()
                   .HasForeignKey(address => address.UserId)
                   .OnDelete(DeleteBehavior.NoAction);
    }
}
