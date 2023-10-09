using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TimeZone.Core.Entities;

namespace TimeZone.DAL.Configurations;

public class SliderConfiguration : IEntityTypeConfiguration<Slider>
{
    public void Configure(EntityTypeBuilder<Slider> builder)
    {
        builder.Property(s => s.SliderImage).IsRequired();
        builder.Property(s => s.Title).IsRequired().HasMaxLength(65);
        builder.Property(s => s.Description).IsRequired().HasMaxLength(250);
    }
}
