using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PracticumFinalOBS.Models
{
    public class Vendor
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Insert Username!")]
        [Display(Name = "Name:")]
        public string VendorName { get; set; }

        [Required(ErrorMessage = "Please Insert Email Address!")]
        [EmailAddress]
        [Display(Name = "Email:")]
        public string VendorEmail { get; set; }

        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Password must be atleast 6 characters")]
        [Required]
        public string VendorPassword { get; set; }

        [DataType(DataType.Password)]
        [Required]
        [Compare("VendorPassword", ErrorMessage = "The Passwords Provided Do Not Match")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Please Insert contact Information!")]
        [Display(Name = "Contact No:")]
        public string VendorPhone { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }

        [Display(Name = "Company Name If Any:")]
        public string VendorCompany { get; set; }      
        
        public bool Status { get; set; }
        
        public List<Book> Book { get; set; }
    }
}
