using Microsoft.EntityFrameworkCore;

namespace Storge.Core.Data;

public class Context : DbContext
{
    public DbSet<User> Users { get; set; }
    
    public string DbPath { get; }

    public Context()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = Path.Combine(path, "storge.db");
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}