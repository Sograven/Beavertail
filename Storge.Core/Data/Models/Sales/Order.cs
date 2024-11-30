using Storge.Core.Data.Models.User;

namespace Storge.Core.Data.Models.Sales
{
    public class Order
    {
        public required int Id { get; set; }
        public required DateTime Data { get; set; }
        public required Account Buyer { get; set; }
        public required List<Item> Items { get; set; }
        public required int Sum { get; set; }
        public string? Address { get; set; }
    }
}
