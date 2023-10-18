//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;
//using TimeZone.Core.Entities;

//namespace TimeZone.DAL.Configurations;

//public class ProductConfiguration : IEntityTypeConfiguration<Product>
//{
//    public void Configure(EntityTypeBuilder<Product> builder)
//    {
//        builder.Property(p => p.ProductImage).IsRequired();
//        builder.Property(p => p.Price).IsRequired();
//        builder.Property(p => p.Brand).IsRequired();
//        builder.Property(p => p.Category).IsRequired();
//        builder.Property(p => p.Title).IsRequired().HasMaxLength(150);

//    }
//}
