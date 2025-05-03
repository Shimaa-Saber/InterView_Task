namespace InterView_Task.DTOs.Reports
{
    public class LowStockReportDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public int Quantity { get; set; }
        public int LowStockThreshold { get; set; }
        public string Status => Quantity <= 0 ? "out of stock" : "low stock";
    }
}
