using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PracticumFinalOBS.Models
{
    public class Catagory
    {
        public int Id { get; set; }

        [Required]
        [Display(Name ="Genre:")]
        public string CatagoryName { get; set; }

        [Display(Name ="Added By:")]
        public int? AdminId { get; set; }

        public Admin Admin { get; set; }

        public List<Book> Book { get; set; }
    }
}
