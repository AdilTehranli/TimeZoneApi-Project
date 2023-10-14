using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TimeZone.Core.Entities;

namespace TimeZone.DAL.Configurations;

public class BlogConfiguration : IEntityTypeConfiguration<Blog>
{
    public void Configure(EntityTypeBuilder<Blog> builder)
    {
        builder.Property(b=>b.BlogImage).IsRequired();
        builder.Property(b=>b.Title).IsRequired();
        builder.Property(b=>b.Description).IsRequired();
    }
}
