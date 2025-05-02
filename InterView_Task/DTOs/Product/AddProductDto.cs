namespace InterView_Task.DTOs.Product
{
    public class AddProductDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public string? Category { get; set; }
        public int LowStockThreshold { get; set; }
    }
}
