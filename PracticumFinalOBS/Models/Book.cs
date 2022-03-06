using System.ComponentModel.DataAnnotations;

namespace PracticumFinalOBS.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        public string BookName { get; set; }

        
        [StringLength(400)]
        public string BookDescription { get; set; }

        public string Image { get; set; }


        public string Publication { get; set; }

        [Display(Name ="Number of Items:")]
        public int NOB { get; set; }

        public double? Quantity { get; set; }

        [Required]
        [Display(Name ="Writer:")]
        public string AuthorName { get; set; }

        [Required]
        public double Price { get; set; }

        public int? CatagoryId { get; set; }

        public Catagory Catagory { get; set; }

        public int? VendorId { get; set; }

        public Vendor Vendor { get; set; }

        public int? CustomerId { get; set; }

        public Customer Customer { get; set; }
    }
}
