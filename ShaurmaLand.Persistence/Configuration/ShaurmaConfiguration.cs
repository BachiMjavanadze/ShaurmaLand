using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShaurmaLand.Domain.Models;

namespace ShaurmaLand.Persistence.Configuration;
public class ShaurmaConfiguration : IEntityTypeConfiguration<Shaurma>
{
    public void Configure(EntityTypeBuilder<Shaurma> shaurmaBuilder)
    {
        shaurmaBuilder.HasKey(shaurma => shaurma.Id);
    }
}
