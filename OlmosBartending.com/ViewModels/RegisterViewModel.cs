using System.ComponentModel.DataAnnotations;

namespace OlmosBartending.com.ViewModels
{
    public class RegisterViewModel:LoginViewModel
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set;}
        [Required]
        public string? Email { get; set; }
    }
}
