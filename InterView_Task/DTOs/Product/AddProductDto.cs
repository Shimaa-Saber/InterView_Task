using System.ComponentModel.DataAnnotations;

namespace InterView_Task.DTOs.Product
{
    public class AddProductDto
    {
        [Required(ErrorMessage = "Product name is required")]
        public string Name { get; set; }
        [StringLength(200)]
        public string Description { get; set; }
        [Required]
        [Range(0.01, 1500)]
        public decimal Price { get; set; }
        [Required]

        public int Quantity { get; set; }
        [StringLength(50)]

        public string? Category { get; set; }
        [Required]
        public int LowStockThreshold { get; set; }
    }
}
