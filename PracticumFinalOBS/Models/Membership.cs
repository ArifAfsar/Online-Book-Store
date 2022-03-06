using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PracticumFinalOBS.Models
{
    public class Membership
    {
        public int Id { get; set; }

        [Required]
        [Display(Name ="Membership Type:")]
        public string MembershipName { get; set; }

        [Required]
        [Display(Name = "Description:")]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Duration In Days:")]
        public int DurationInDays { get; set; }

        [Required]
        [Display(Name = "Discount Rate:")]
        public int DiscountRate { get; set; }
        [Required]
        [Display(Name = "Fee:")]
        public double Fee { get; set; }
        public List<Customer> Customer { get; set; }
    }
}
