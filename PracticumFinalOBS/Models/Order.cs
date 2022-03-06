
namespace PracticumFinalOBS.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
        public string InvoiceNo { get; set; }
        public double Quantity { get; set; }
        public double SubTotal { get; set; }
        public string BkashNumber { get; set; }
        public int VendorId { get; set; }
        public Vendor Vendor { get; set; }
        public string ShippingAddress { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}