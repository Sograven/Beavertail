using Microsoft.EntityFrameworkCore;
using Storge.Core.Data.Models;

namespace Storge.Core.Data.Contexts;

/// <summary>
/// Provides access to all users in the database.
/// </summary>
internal class AllUsersContext : DbContext
{
    /// <summary>
    /// List of all users in the database.
    /// </summary>
    internal DbSet<User>? Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite($"Data Source = {Config.UsersFilePath}");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(
            user =>
            {
                user.Property(u => u.UserID).ValueGeneratedOnAdd().IsRequired();
                user.Property(u => u.FirstName).IsRequired();
                user.Property(u => u.TelegramID).IsRequired();

                user.HasIndex(u => u.UserID).IsUnique();
                user.HasIndex(u => u.TelegramID).IsUnique();
            });
    }
}
