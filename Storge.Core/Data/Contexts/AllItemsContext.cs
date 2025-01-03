using Microsoft.EntityFrameworkCore;
using Storge.Core.Data.Models;

namespace Storge.Core.Data.Contexts;

/// <summary>
/// Provides access to all items in the database.
/// </summary>
internal class AllItemsContext : DbContext
{
    /// <summary>
    /// List of all items in the database.
    /// </summary>
    internal DbSet<Item>? Items { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite($"Data Source = {Config.ItemsFilePath}");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Item>(
            item =>
            {
                item.Property(i => i.ID).IsRequired();
                item.Property(i => i.Name).IsRequired();
                item.Property(i => i.Color).IsRequired();
                item.Property(i => i.Size).IsRequired();
                item.Property(i => i.Category).IsRequired();

                item.HasIndex(i => i.ID).IsUnique();
            });
    }
}
