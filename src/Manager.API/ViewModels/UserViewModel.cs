using System.ComponentModel.DataAnnotations;

namespace Manager.API.ViewModels
{
    public class CreateUserViewModel
    {
        [Required(ErrorMessage = "The name is required")]
        [MinLength(2, ErrorMessage = "The name must have at least 2 characters")]
        [MaxLength(100, ErrorMessage = "The name must have at most 100 characters")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "The email is required")]
        [EmailAddress(ErrorMessage = "The email is invalid")]
        [MaxLength(100, ErrorMessage = "The email must have at most 100 characters")]
        [MinLength(5, ErrorMessage = "The email must have at least 5 characters")]
        public string Email { get; set; }

        [Required(ErrorMessage = "The password is required")]
        [MinLength(6, ErrorMessage = "The password must have at least 6 characters")]
        [MaxLength(100, ErrorMessage = "The password must have at most 100 characters")]
        public string Password { get; set; }
    }
}