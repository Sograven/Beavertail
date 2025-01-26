using Microsoft.EntityFrameworkCore;
using Storge.Core.Data.Models;

namespace Storge.Core.Data.Contexts;

public class AllUsersContext : DbContext
{
   public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite($"Data Source = {Config.UsersFilePath}");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(
            user =>
            {
                user.Property(u => u.Id).ValueGeneratedOnAdd();
            });
    }
}