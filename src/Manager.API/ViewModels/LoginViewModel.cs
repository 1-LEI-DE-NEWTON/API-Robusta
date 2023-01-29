using System.ComponentModel.DataAnnotations;
using Manager.API.Token;
using Microsoft.AspNetCore.Mvc;

namespace Manager.API.Controller
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Login is required")]
        public string Login { get; set; }
        
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}