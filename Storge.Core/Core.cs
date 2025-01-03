using Storge.Core.Data.Contexts;
using Storge.Core.Data.Mappers;

namespace Storge.Core;

public static class Core
{
    public static void Method()
    {
        var db = new AllUsersContext();
        foreach (var u in db.Users)
        {
            Console.WriteLine($"{u.UserID} {u.FirstName} {u.TelegramID}");
        }
    }
}