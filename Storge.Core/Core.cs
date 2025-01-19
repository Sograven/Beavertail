using Storge.Core.Data.Contexts;
using Storge.Core.Data.Models;

namespace Storge.Core;

public static class Core
{
    /// <summary>
    /// Prints all orders saved in the database.
    /// </summary>
    internal static void PrintAllOrders()
    {
        var db = new AllOrdersContext();

        Console.WriteLine("OrderID   | UserID    | Sum");
        foreach (var o in db.Orders)
        {
            Console.WriteLine($"{o.Id} {o.UserId} {o.Sum}");
        }
    }

    /// <summary>
    /// Prints order details by <paramref name="orderId"/>.
    /// </summary>
    /// <param name="orderId"></param>
    internal static void PrintOrderDetails(int orderId)
    {
        var db = new AllOrdersContext();
        var order = db.Orders.Single(o => o.Id == orderId);

        Console.WriteLine($"OrderID: {order.Id}\n" +
            $"UserID: {order.UserId}\n" +
            $"Address: {order.Address}\n" +
            $"Sum: {order.Sum}\n" +
            $"Positions:");

        foreach (var p in order.Positions)
        {
            Console.WriteLine($"- Article: {p.Article}; Amount: {p.Amount}; Price: {p.Price}");
        }
    }
}