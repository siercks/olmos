using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace OlmosBartending.com.Models
{
    public class User:IdentityUser
    {
        [System.ComponentModel.DataAnnotations.Key]
        //public int CustomerId { get; set; }
        //public string? UserName { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set;}
    }
}
