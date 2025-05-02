using System.ComponentModel.DataAnnotations;

namespace InterView_Task.DTOs.Transaction
{
    public class AddStockDto
    {
        [Required]
        public int ProductId { get; set; }

        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }

        public int? DestinationWarehouseId { get; set; }
    }
}
