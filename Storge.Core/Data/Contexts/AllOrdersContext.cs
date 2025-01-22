using Microsoft.EntityFrameworkCore;
using Storge.Core.Data.Models;

namespace Storge.Core.Data.Contexts;

/// <summary>
/// Provides access to all orders in the database.
/// </summary>
internal class AllOrdersContext : DbContext
{
    /// <summary>
    /// List of all orders in the database.
    /// </summary>
    internal DbSet<Order>? Orders { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite($"Data Source = {Config.OrdersFilePath}");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Order>().OwnsMany(
            o => o.Positions, p =>
            {
                p.WithOwner().HasForeignKey("OrderId");
                p.Property<int>("Id");
                p.HasKey("Id");
            });
    }
}
