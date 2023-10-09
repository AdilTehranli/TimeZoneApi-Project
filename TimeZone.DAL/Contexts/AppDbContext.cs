﻿using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TimeZone.Core.Entities;

namespace TimeZone.DAL.Contexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }
   public DbSet<Slider> Sliders { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}
