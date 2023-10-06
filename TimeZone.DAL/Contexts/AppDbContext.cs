using Microsoft.EntityFrameworkCore;

namespace TimeZone.DAL.Contexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }
}
