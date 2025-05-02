using InterView_Task.Enums;

namespace InterView_Task.DTOs.Transaction
{
    public class TransactionDto
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public TransactionType TransactionType { get; set; }

       
        public int? SourceId { get; set; }
        public int? DestinationId { get; set; }
    }
}
