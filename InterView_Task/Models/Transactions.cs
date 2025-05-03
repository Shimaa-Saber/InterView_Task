using InterView_Task.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace InterView_Task.Models
{
    public class InventoryTransactions
    {
        public int Id { get; set; }
        public string ?ProductName { get; set; }
        public decimal? Price { get; set; }
        public int Quantity { get; set; }
        public DateTime ?TransactionDate { get; set; }
        public TransactionType TransactionType { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        [ForeignKey("Source")]
        public int? SourceId { get; set; }
        [ForeignKey("Destination")]
      

        public int? DestinationId { get; set; }
        [ForeignKey("User")]
        public string? UserId { get; set; }
        public Product ?Product { get; set; }

        public Warehouse? Source { get; set; }
        public Warehouse? Destination { get; set; }
        public ApplicationUser? User { get; set; }

    }
}
