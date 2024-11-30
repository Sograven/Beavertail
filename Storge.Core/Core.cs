using Storge.Core.Data;
using Storge.Core.Data.Models;

namespace Storge.Core;

public static class Core
{
    public static void AddUser(Account user)
    {
        var db = new AccountContext();
        db.Accounts.Add(user);
        db.SaveChanges();
    }
    
    public static Account GetUser(int id)
    {
        var db = new AccountContext();

        return db.Accounts.Single(u => u.Id == id);
    }
}