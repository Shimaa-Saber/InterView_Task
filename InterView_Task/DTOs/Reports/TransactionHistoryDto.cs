namespace InterView_Task.DTOs.Reports
{
    public class TransactionHistoryDto
    {
        public int Id { get; set; }
        public DateTime? TransactionDate { get; set; }
        public string TransactionType { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public string User { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
      
    }
}


