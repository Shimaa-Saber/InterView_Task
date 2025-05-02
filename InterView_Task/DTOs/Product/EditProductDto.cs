using System.ComponentModel.DataAnnotations;

namespace InterView_Task.DTOs.Product
{
    public class EditProductDto
    {
       
            [Required] public int Id { get; set; }  
            [StringLength(100)] public string? Name { get; set; }  
            public string? Description { get; set; } 
            [Range(0.01, 1500)] public decimal? Price { get; set; } 
            [Range(0, int.MaxValue)] public int? Quantity { get; set; } 
            public string? Category { get; set; }  
            [Range(1, int.MaxValue)] public int? LowStockThreshold { get; set; }  
        
    }
}
