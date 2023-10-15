using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TimeZone.Core.Entities;

namespace TimeZone.DAL.Configurations;

public class WrapperConfiguration : IEntityTypeConfiguration<Wrapper>
{
    public void Configure(EntityTypeBuilder<Wrapper> builder)
    {
        builder.Property(w => w.Icon).IsRequired();
        builder.Property(w => w.Title).IsRequired();
        builder.Property(w => w.Description).IsRequired();
    }
}
