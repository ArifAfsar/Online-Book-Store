using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PracticumFinalOBS.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        public string CustomerName { get; set; }

        [Required]
        [EmailAddress]
        public string CustomerEmail { get; set; }

        [DataType(DataType.Password)]
        [MinLength(6,ErrorMessage ="Password must be atleast 6 characters")]
        [Required]
        public string CustomerPassword { get; set; }

        [DataType(DataType.Password)]
        [Required]
        [Compare("CustomerPassword", ErrorMessage ="The Passwords Provided Do Not Match")]
        public string ConfirmPassword { get; set; }

        [DataType(DataType.Date)]
        public DateTime CustomerDOB { get; set; }

        [Required]
        [Display(Name ="Address:")]
        public string CustomerAddress { get; set; }

        [Required]
        [MaxLength(12,ErrorMessage ="Mobile Number not Valid")]
        public string CustomerPhone { get; set; }
        [DataType(DataType.Date)]
        public DateTime? MembershipDate { get; set; }
        public int? MembershipId { get; set; }

        public Membership Membership { get; set; }

    }
}
