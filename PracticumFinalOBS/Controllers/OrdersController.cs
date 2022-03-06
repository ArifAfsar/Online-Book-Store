using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PracticumFinalOBS.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PracticumFinalOBS.Data;
using PracticumFinalOBS.Models;

namespace PracticumFinalOBS.Controllers
{
    public class OrdersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _usermanager;

        public OrdersController(ApplicationDbContext context, UserManager<IdentityUser> usermanager)
        {
            _usermanager = usermanager;
            _context = context;
        }

        // GET: Orders
        public IActionResult Index()
        {
            var applicationDbContext = _context.Order.Include(o => o.Book).Include(o => o.Customer).Include(o => o.Vendor);
            var result =applicationDbContext.ToList().GroupBy(x=>x.CustomerId)
                        .Select(y => y.First()).ToList();
           
            return View(result);
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? cid)
        {
            if (cid == null)
            {
                return NotFound();
            }
            var target =await _context.Customer.Where(x => x.Id == cid).FirstOrDefaultAsync();
            var member = await _context.Membership.Where(n => n.Id == target.MembershipId)
                .FirstOrDefaultAsync();
            if (member == null)
            {
                ViewBag.discount = 0;
            }
            else
            {
                ViewBag.discount = member.DiscountRate;
            }
            var order = await _context.Order
                .Include(o => o.Book)
                .Include(o => o.Customer)
                .Include(o => o.Vendor)
                .Where(c=>c.CustomerId == cid)
                .ToListAsync();
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            var c = HttpContext.Session.GetObject<Cart>("mycart");
            if (c != null)
            {
                List<Book> booklist = c.Books;
                ViewBag.cart = booklist;
            }
            else
            {
                return NotFound();
            }
            var u = User.Identity.Name;
            var target = _context.Customer.Where(c => c.CustomerEmail == u).FirstOrDefault();
           
            var member = _context.Membership.Where(x=>x.Id==target.MembershipId).FirstOrDefault();
            if (member == null)
            {
                ViewBag.discount = 0;
            }
            else
            {
                ViewBag.discount = member.DiscountRate;
            }
           
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BkashNumber,ShippingAddress")] Order order)
        {
            
            var r = _usermanager.GetUserName(HttpContext.User);
            var target = await _context.Customer.Where(c => c.CustomerEmail == r).FirstOrDefaultAsync();
           

            if (ModelState.IsValid)
            {
                var x = HttpContext.Session.GetObject<Cart>("mycart");
                //var y = await _context.Order.ToListAsync();

                Guid invoice = Guid.NewGuid();
                foreach (var item in x.Books)
                {
                    Order or = new Order();
                    or.BookId = item.Id;
                    or.CustomerId = target.Id;
                    or.VendorId = item.VendorId.Value;
                    or.Quantity = item.Quantity.Value;
                    or.SubTotal = item.Price * item.Quantity.Value;
                    or.BkashNumber = order.BkashNumber;
                    or.InvoiceNo = invoice.ToString().Replace("-","");
                    or.ShippingAddress = order.ShippingAddress;
                    _context.Add(or);
                    await _context.SaveChangesAsync();
                }
                var c = HttpContext.Session.GetObject<Cart>("mycart");
                if (c != null)
                {

                    var member = _context.Membership.Where(x => x.Id == target.MembershipId).FirstOrDefault();
                    if (member == null)
                    {
                        ViewBag.discount = 0;
                    }
                    else
                    {
                        ViewBag.discount = member.DiscountRate;
                    }
                    var or = _context.Order.Where(x => x.CustomerId == target.Id).FirstOrDefault();
                    ViewBag.Bkash = or.BkashNumber.ToString();
                    ViewBag.INV = or.InvoiceNo;
                    ViewBag.sp = or.ShippingAddress.ToString();
                    ViewBag.cus = target.CustomerName;
                    ViewBag.EA = target.CustomerEmail;
                    List<Book> booklist = c.Books;
                    HttpContext.Session.Clear();
                    return View("Invoice", booklist);
                }
                else
                {
                    return NotFound();
                }
            }
            return View(order);
           
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Order.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            ViewData["BookId"] = new SelectList(_context.Book, "Id", "AuthorName", order.BookId);
            ViewData["CustomerId"] = new SelectList(_context.Customer, "Id", "ConfirmPassword", order.CustomerId);
            ViewData["VendorId"] = new SelectList(_context.Vendor, "Id", "VendorEmail", order.VendorId);
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BookId,Quantity,SubTotal,BkashNumber,VendorId,TransactionCode,ShippingAddress,CustomerId")] Order order)
        {
            if (id != order.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(order);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(order.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["BookId"] = new SelectList(_context.Book, "Id", "AuthorName", order.BookId);
            ViewData["CustomerId"] = new SelectList(_context.Customer, "Id", "ConfirmPassword", order.CustomerId);
            ViewData["VendorId"] = new SelectList(_context.Vendor, "Id", "VendorEmail", order.VendorId);
            return View(order);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Order
                .Include(o => o.Book)
                .Include(o => o.Customer)
                .Include(o => o.Vendor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order = await _context.Order.FindAsync(id);
            _context.Order.Remove(order);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(int id)
        {
            return _context.Order.Any(e => e.Id == id);
        }
    }
}
