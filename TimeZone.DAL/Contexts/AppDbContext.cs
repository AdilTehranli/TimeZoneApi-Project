using Microsoft.EntityFrameworkCore;
using TimeZone.Core.Entities;

namespace TimeZone.DAL.Contexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }
   public DbSet<Slider> Sliders { get; set; }
}
