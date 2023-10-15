using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TimeZone.Core.Entities;

namespace TimeZone.DAL.Configurations;

public class BannerConfiguration : IEntityTypeConfiguration<Banner>
{
    public void Configure(EntityTypeBuilder<Banner> builder)
    {
        builder.Property(b=>b.BannerImage).IsRequired();
        builder.Property(b=>b.Title).IsRequired();
        builder.Property(b=>b.Price).IsRequired();

    }
}
