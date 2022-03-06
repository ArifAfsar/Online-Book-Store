using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace PracticumFinalOBS.Models
{
    public class Admin
    {
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "The Passwords Do Not Match!!!")]
        public string ConfirmPassword { get; set; }

        [Required]
        [StringLength(12)]
        public string Contact { get; set; }

        public List<Catagory> Catagory { get; set; }
    }
}
