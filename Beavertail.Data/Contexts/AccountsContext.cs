using Beavertail.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Beavertail.Data.Contexts;

public class AccountsContext : DbContext
{
    public DbSet<Account> Accounts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite($"Data Source = {Config.UsersFilePath}");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(
            user =>
            {
                user.Property(u => u.ID).ValueGeneratedOnAdd();
            });
    }
}