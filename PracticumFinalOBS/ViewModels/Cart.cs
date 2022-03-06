using PracticumFinalOBS.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PracticumFinalOBS.ViewModels
{
    public class Cart
    {
        public Cart()
        {
            Books = new List<Book>();
        }
        public List<Book> Books { get; set; }
        public string ShippingAddress { get; set; }

        public int? CustomerId { get; set; }

        public Customer Customer { get; set; }

        [StringLength(12,ErrorMessage="Contact Number Must be Less than 12 digits")]
       public string Contact { get; set; }

    }
}
