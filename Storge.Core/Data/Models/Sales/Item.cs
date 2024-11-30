namespace Storge.Core.Data.Models.Sales
{
    public class Item
    {
        public required string Article { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required int BuyPrice { get; set; }
        public required int SellPrice { get; set; }
        public required List<int> Sizes { get; set; }
    }
}
