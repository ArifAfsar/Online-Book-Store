using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using PracticumFinalOBS.Models;

namespace PracticumFinalOBS.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<PracticumFinalOBS.Models.Admin> Admin { get; set; }
        public DbSet<PracticumFinalOBS.Models.Catagory> Catagory { get; set; }
        public DbSet<PracticumFinalOBS.Models.Vendor> Vendor { get; set; }
        public DbSet<PracticumFinalOBS.Models.Customer> Customer { get; set; }
        public DbSet<PracticumFinalOBS.Models.Book> Book { get; set; }
        public DbSet<PracticumFinalOBS.Models.Order> Order { get; set; }
        public DbSet<PracticumFinalOBS.Models.Membership> Membership { get; set; }
        public DbSet<PracticumFinalOBS.Models.Sales> Sales { get; set; }
        public DbSet<PracticumFinalOBS.Models.Online> Online { get; set; }


    }
}
