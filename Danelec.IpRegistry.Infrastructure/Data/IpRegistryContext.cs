using Danelec.IpRegistry.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Danelec.IpRegistry.Infrastructure.Data;

public class IpRegistryContext : DbContext
{
    public DbSet<IpRegistration> IpRegistrations { get; set; }
    public string DbPath { get; }

    public IpRegistryContext()
    {
        var path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        DbPath = Path.Join(path, "ip.db");
    }

    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<IpRegistration>()
            .HasIndex(u => u.Ip)
            .IsUnique();
    }
}