using Microsoft.EntityFrameworkCore;
using Storge.Core.Data.Models;

namespace Storge.Core.Data;

public class UserContext : DbContext
{
    public DbSet<User> Users { get; set; }

    private string DbPath { get; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
    
    public UserContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "users.db");
    }
}