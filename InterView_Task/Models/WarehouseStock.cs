using System.ComponentModel.DataAnnotations.Schema;

namespace InterView_Task.Models
{
    public class WarehouseStock
    {
        public int Id { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product Product { get; set; }

        [ForeignKey("Warehouse")]
        public int WarehouseId { get; set; }
        public Warehouse Warehouse { get; set; }

        public int Quantity { get; set; }
    }
}
