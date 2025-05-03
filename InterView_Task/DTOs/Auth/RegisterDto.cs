using System.ComponentModel.DataAnnotations;

namespace InterView_Task.DTOs.Auth
{
    public class RegisterDto
    {
        [Required(ErrorMessage = "User name is required")]
        [StringLength(50, MinimumLength = 3,
           ErrorMessage = "User name must be between 3 and 50 characters")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(100, MinimumLength = 6,
            ErrorMessage = "Password must be at least 6 characters")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please confirm your password")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password),
            ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; }

      

    }
}
