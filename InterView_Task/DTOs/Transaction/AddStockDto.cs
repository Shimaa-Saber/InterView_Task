using System.ComponentModel.DataAnnotations;

namespace InterView_Task.DTOs.Transaction
{
    public class AddStockDto
    {
        [Required]
        public int ProductId { get; set; }

        [Range(1, 100)]
        public int Quantity { get; set; }

        public int? DestinationId { get; set; }

        public int? SourceId { get; set; }
    }
}
