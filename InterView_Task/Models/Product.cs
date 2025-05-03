using System.Transactions;

namespace InterView_Task.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string ?ImageUrl { get; set; }
        public string? Category { get; set; }
        public int LowStockThreshold { get; set; }

        public List<InventoryTransactions>? Transactions { get; set; }
        public List<WarehouseStock> ?WarehouseStocks { get; set; }
    }
}
