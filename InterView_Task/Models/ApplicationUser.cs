using Microsoft.AspNetCore.Identity;

namespace InterView_Task.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string ?FirstName { get; set; }
        public string? LastName { get; set; }
      
        public string ? PhoneNumber { get; set; }
       
        public string? Role { get; set; }
        public List<InventoryTransactions>? Transactions { get; set; }
    }
    
    }

