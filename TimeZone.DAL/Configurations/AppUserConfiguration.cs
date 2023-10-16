using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TimeZone.Core.Entities;

namespace TimeZone.DAL.Configurations;

public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
{
    public void Configure(EntityTypeBuilder<AppUser> builder)
    {
        builder.Property(a=>a.Name).IsRequired().HasMaxLength(35);
        builder.Property(a=>a.Surname).IsRequired().HasMaxLength(50);
    }
}
