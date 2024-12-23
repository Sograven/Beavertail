using Microsoft.EntityFrameworkCore;
using Storge.Core.Data.Models;

namespace Storge.Core.Data.Contexts;

/// <summary>
/// Provides access to all users in database.
/// </summary>
internal class AllUsersContext : DbContext
{
    internal DbSet<User> Users { get; set; }

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
                user.Property(u => u.TelegramID).HasDefaultValue(-1);
            });
    }
}
