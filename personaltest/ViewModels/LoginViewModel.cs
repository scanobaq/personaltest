using System.ComponentModel.DataAnnotations;

namespace personaltest.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string? Username { get; set; }
        [Required]
        [MinLength(6)]
        public string? Password { get; set; }
    }
}