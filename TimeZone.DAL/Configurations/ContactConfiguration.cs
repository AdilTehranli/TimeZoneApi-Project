using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TimeZone.Core.Entities;

namespace TimeZone.DAL.Configurations;

public class ContactConfiguration : IEntityTypeConfiguration<Contact>
{
    public void Configure(EntityTypeBuilder<Contact> builder)
    {
        builder.Property(c=>c.Message).IsRequired();
        builder.Property(c=>c.MailAddress).IsRequired();
        builder.Property(c=>c.Subject).IsRequired();
        builder.Property(c=>c.Name).IsRequired();
    }
}
