using System;
using System.ComponentModel.DataAnnotations;

namespace PracticumFinalOBS.Models
{
    public class Sales
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int VendorId { get; set; }
        public Vendor Vendor { get; set; }
        [DataType(DataType.Date)]
        public DateTime SaleDate { get; set; }
        public double Quantity { get; set; }
        public double SubTotal { get; set; }
    }
}
