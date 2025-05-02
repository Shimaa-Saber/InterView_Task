using System.ComponentModel.DataAnnotations;

namespace InterView_Task.DTOs.Transaction
{
    public class TransferStockDto
    {
        [Required]
        public int ProductId { get; set; }

        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }

        [Required]
        public int SourceId { get; set; }

        [Required]
        public int DestinationId { get; set; }
    }
}
