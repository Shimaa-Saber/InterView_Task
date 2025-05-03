using System.ComponentModel.DataAnnotations;

namespace InterView_Task.DTOs.Transaction
{
    public class RemoveStockDto
    {
        [Required]
        public int ProductId { get; set; }

        [Range(1, 100)]
        public int Quantity { get; set; }

        public int? SourceId { get; set; }
        public int? DestinationId { get; set; }
    }
}
