using Storge.Core.Data;
using Storge.Core.Data.Models;

namespace Storge.Core;

public static class Core
{
    public static void AddUser(User user)
    {
        var db = new UserContext();

        db.Add(user);
        db.SaveChanges();
    }
    
    public static User GetUser(int id)
    {
        var db = new UserContext();

        return db.Users.Single(u => u.Id == id);
    }
}