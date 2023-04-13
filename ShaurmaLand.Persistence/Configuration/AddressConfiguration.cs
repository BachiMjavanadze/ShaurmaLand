using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShaurmaLand.Domain.Models;

namespace ShaurmaLand.Persistence.Configuration;
public class AddressConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> addressBuilder)
    {
        addressBuilder.HasKey(address => address.Id);
    }
}
