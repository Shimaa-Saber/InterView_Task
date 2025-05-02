using System.Transactions;

namespace InterView_Task.Models
{
    public class Warehouse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }

        public List<InventoryTransactions> ? SourceTransactions { get; set; }
        public List<InventoryTransactions>? DestinationTransactions { get; set; }
    }
}
