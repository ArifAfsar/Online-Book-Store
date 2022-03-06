using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using PracticumFinalOBS.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PracticumFinalOBS.Data;
using PracticumFinalOBS.Models;

namespace PracticumFinalOBS.Controllers
{
    public class BooksController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _usermanager;
        private readonly IWebHostEnvironment _henv;

        public BooksController(ApplicationDbContext context, IWebHostEnvironment henv, UserManager<IdentityUser> usermanager)
        {
            _usermanager = usermanager;
            _henv = henv;
            _context = context;
        }

        public async Task<IActionResult> Index(string booksrch, string catagory)
        {
            List<string> l = new List<string>();
            var cata = await _context.Catagory.ToListAsync();
            foreach (var item in cata)
            {
                l.Add(item.CatagoryName);
            }
            ViewBag.cat = l;
            if (string.IsNullOrEmpty(catagory))
            {
                if (string.IsNullOrEmpty(booksrch))
                {
                    booksrch = "";
                }
                var books = await _context.Book.Include(b => b.Catagory).Include(b => b.Vendor).ToListAsync();

                var x = from book in books
                        where book.BookName.ToUpper().Contains(booksrch.ToUpper())
                        orderby book.Image
                        select book;
                
                ViewBag.book = booksrch;
                return View(x);

            }
            if (string.IsNullOrEmpty(booksrch))
            {
                booksrch = "";
            }
            var applicationDbContext = await _context.Book.Include(b => b.Catagory).Include(b => b.Vendor).ToListAsync();

            var result = from book in applicationDbContext
                         where
                         book.BookName.ToUpper().Contains(booksrch.ToUpper()) &&
                         book.Catagory.CatagoryName.Equals(catagory)
                         orderby book.Image
                         select book;
           
            ViewBag.values = catagory;
            return View(result);
        }




        ////////////////////////Alternative Index with errors, FIX LATER ////////////////////////////////////////////


        //public async Task<IActionResult> Index(string booksrch, string catagory)
        //{
        //    List<string> l = new List<string>();
        //    var cata = await _context.Catagory.ToListAsync();
        //    foreach (var item in cata)
        //    {
        //        l.Add(item.CatagoryName);
        //    }
        //    ViewBag.cat = l;
        //    if (string.IsNullOrEmpty(catagory))
        //    {
        //        catagory = "";
        //    }
        //    if (string.IsNullOrEmpty(booksrch))
        //    {
        //        booksrch = "";
        //    }
        //    var books = await _context.Book.Include(b => b.Catagory).Include(b => b.Vendor).ToListAsync();

        //    var x = from book in books
        //            where book.BookName.ToUpper().Contains(booksrch.ToUpper()) || book.Catagory.CatagoryName.Equals(catagory)
        //            orderby book.Image
        //            select book;

        //    ViewBag.book = booksrch;
        //    return View(x);

        //}


        // GET: Books/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Book
                .Include(b => b.Catagory)
                .Include(b => b.Customer)
                .Include(b => b.Vendor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }
        [Authorize(Roles ="Vendor")]

        // GET: Books/Create
        public IActionResult Create()
        {
            ViewData["CatagoryId"] = new SelectList(_context.Catagory, "Id", "CatagoryName");
            
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,BookName,BookDescription,Publication,NOB,AuthorName,Price,CatagoryId,VendorId")] Book book,IFormFile Image)
        {
            if (ModelState.IsValid)
            {
                if (Image != null)
                {
                    var root = _henv.WebRootPath;
                    var dir = "Books";
                    var fname = Path.GetFileName(Image.FileName);

                    string filename = Path.Combine(root, dir, fname);

                    using (var stream = new FileStream(filename, FileMode.Create))
                    {
                        await Image.CopyToAsync(stream);
                    }
                    book.Image = fname;
                }
                else
                {
                    book.Image = "-";

                }
                
                var r = _usermanager.GetUserName(HttpContext.User);
                var target = await _context.Vendor.Where(n => n.VendorEmail == r).FirstOrDefaultAsync();
                book.VendorId = target.Id; 
                _context.Add(book);
                await _context.SaveChangesAsync();
                return RedirectToAction("Inventory","Vendors");
            }
            ViewData["CatagoryId"] = new SelectList(_context.Catagory, "Id", "CatagoryName", book.CatagoryId);
            ViewData["VendorId"] = new SelectList(_context.Vendor, "Id", "VendorEmail", book.VendorId);
            return View(book);
        }

        // GET: Books/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Book.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            ViewData["CatagoryId"] = new SelectList(_context.Catagory, "Id", "CatagoryName", book.CatagoryId);
            
            return View(book);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BookName,BookDescription,Publication,NOB,AuthorName,Price,CatagoryId")] Book book, IFormFile Image)
        {
            if (id != book.Id)
            {
                return NotFound();
            }
            var vendorname = _usermanager.GetUserName(HttpContext.User);
            Vendor vend =await _context.Vendor.Where(n => n.VendorEmail == User.Identity.Name).FirstOrDefaultAsync();
            book.VendorId = vend.Id;
            if (Image != null)
            {
                var root = _henv.WebRootPath;
                var dir = "Books";
                var fname = Path.GetFileName(Image.FileName);

                string filename = Path.Combine(root, dir, fname);

                using (var stream = new FileStream(filename, FileMode.Create))
                {
                    await Image.CopyToAsync(stream);
                }
                book.Image = fname;
            }
            else
            {
                book.Image = "-";

            }

            if (ModelState.IsValid)
                {                    
                    try
                    {
                        _context.Update(book);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!BookExists(book.Id))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                    return RedirectToAction("Inventory", "Vendors");
                }
           
            ViewData["CatagoryId"] = new SelectList(_context.Catagory, "Id", "CatagoryName", book.CatagoryId);
            return View(book);
        }

       

        //Try 1: Add to Cart
        
        
        public JsonResult AddToCart(int pid, int qty)
        {
            var bb = _context.Book.FirstOrDefault(n => n.Id == pid);
            if (bb.NOB == 0)
            {
                return Json(new { flag = "0", msg = "Sorry, This item is no longer available" });
            }
            string message = "";
            if (!User.IsInRole("Customer"))
            {
                message = "Please login To continue";
                return Json(new { flag = "0", msg = message });
            }
            
            var extcart = HttpContext.Session.GetObject<Cart>("mycart");
            var cusname = _usermanager.GetUserName(HttpContext.User);
            
            var target = _context.Customer.Where(n => n.CustomerEmail == cusname).FirstOrDefault();
            var memtemp = target.MembershipDate;
            var mem = _context.Membership.Where(n=>n.Id == target.MembershipId).FirstOrDefault();
            if (target.MembershipId != null)
            {
                var duration = mem.DurationInDays;
                var over = memtemp.Value.AddDays(duration);
                if (DateTime.Today > over)
                {
                    target.MembershipId = null;
                    target.MembershipDate = null;
                    _context.Update(target);
                    _context.SaveChanges();
                }
            }

            int x = target.Id;
            
            
            
            if (extcart == null) //No Product in Cart Yet
            {
                var p = _context.Book.FirstOrDefault(n => n.Id == pid);
                //Retrieve Product from context with pid
                if (p != null) //Product Exists
                {
                    p.Quantity = qty;
                    Cart c = new Cart();
                    c.Books.Add(p);
                    c.CustomerId = x;
                    //Product added to Cart
                    HttpContext.Session.SetObject("mycart", c); //Set In Session
                    message = "Product has been added successfully to empty cart";
                    return Json(new { flag = "1", msg = message });
                }
                else
                {
                    message = "Sorry!Invalid Product has been choosen";
                    return Json(new { flag = "0", msg = message });
                }

            }
            else
            {
                var p1 = extcart.Books.FirstOrDefault(x => x.Id == pid); //Check if Same Product is Already in Cart
                if (p1 != null)
                {                  
                    p1.Quantity += qty; //Product already in cart, just increase quantity
                    extcart.CustomerId = x;
                    HttpContext.Session.SetObject("mycart", extcart); //Update session object
                    message = "Same Product Has been added to existing cart";
                    return Json(new { flag = "1", msg = message });
                }
                else
                {
                    //Choosen Product Not In Cart
                    var p2 = _context.Book.FirstOrDefault(x => x.Id == pid);
                    if (p2 != null)
                    {
                        p2.Quantity = qty;
                        extcart.Books.Add(p2);
                        extcart.CustomerId = x;
                        HttpContext.Session.SetObject("mycart", extcart);
                        message = "New Product has been added to cart";
                        return Json(new { flag = "1", msg = message });
                    }
                    else
                    {
                        message = "Invalid Product is selected";
                        return Json(new { flag = "0", msg = message });
                    }
                }
            }
        }


        //Show Cart Try
        [Authorize(Roles ="Customer")]
        public async Task<IActionResult> showcart()
        {
            var name = User.Identity.Name;
            var target =await _context.Customer.Where(n=>n.CustomerEmail == name).SingleOrDefaultAsync();
            var member =await _context.Membership.Where(n=>n.Id == target.MembershipId).FirstOrDefaultAsync();
            if (member == null)
            {
                ViewBag.Discount = 0;
            }
            else
            {
                ViewBag.Discount = member.DiscountRate;
            }
            var c = HttpContext.Session.GetObject<Cart>("mycart");
            if (c != null)
            {
                List<Book> booklist = c.Books;
                return View(booklist);
            }
            else
            {
                return View();
            }
        }


        //Remove From Cart Try 1 

        public JsonResult RemoveFromCart(int pid)
        {

            var c = HttpContext.Session.GetObject<Cart>("mycart");
            if (c != null)
            {
                var p = c.Books.FirstOrDefault(x => x.Id == pid);
                if (p != null)
                {
                    c.Books.Remove(p);
                    HttpContext.Session.SetObject<Cart>("mycart", c);
                    return Json(new { flag = "1", msg = "Product has been Removed Successfully" });
                }
                else
                {
                    return Json(new { flag = "0", msg = "Product does not exist in the cart" });
                }

            }
            else
            {
                return Json(new { flag = "0", msg = "Cart is Empty" });
            }
        }


        //Update Quantity of Items In Cart (First Try)

        public JsonResult ChangeQuantity(int pid, int plusminus)
        {
            var b = _context.Book.FirstOrDefault(x => x.Id == pid);
            var c = HttpContext.Session.GetObject<Cart>("mycart");
            if (c != null)
            {
                var p = c.Books.FirstOrDefault(x => x.Id == pid);
                if (p != null)
                {
                    if (plusminus == 1)
                    {
                        if(p.Quantity == b.NOB)
                        {
                            return Json(new { flag = "0", msg = "Maximum Limit Reached" });
                        }
                        p.Quantity++;
                    }
                    else
                    {
                        double qty = p.Quantity.Value;
                        if (qty > 1)
                        {
                            p.Quantity -= 1;
                        }
                        else
                        {
                            c.Books.Remove(p);
                        }
                    }

                    HttpContext.Session.SetObject<Cart>("mycart", c);
                    return Json(new { flag = "1", msg = "Product Quantity Updated Successfully" });
                }
                else
                {
                    return Json(new { flag = "0", msg = "Product does not exist in the cart" });
                }

            }
            else
            {
                return Json(new { flag = "0", msg = "Cart is Empty" });
            }
        }



        // GET: Books/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Book
                .Include(b => b.Catagory)
                .Include(b => b.Customer)
                .Include(b => b.Vendor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }
        //public IActionResult Order()
        //{
        //    var ob = HttpContext.Session.GetObject<Cart>("mycart");
        //    List<Book> orderbooks = new List<Book>();
        //    foreach (var item in ob.Books)
        //    {
        //        orderbooks.Add(item);
        //    }
        //    return View(orderbooks);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Order(string bkash,string trcode,string SA)
        //{
        //    if (string.IsNullOrEmpty(bkash))
        //    {
        //        bkash = "";
        //    }
        //    if (string.IsNullOrEmpty(trcode))
        //    {
        //        trcode = "";
        //    }
        //    if (string.IsNullOrEmpty(bkash))
        //    {
        //        SA = "";
        //    }
        //    var ob = HttpContext.Session.GetObject<Cart>("mycart");
        //    List<Book> orderbooks = new List<Book>();
        //    var x = HttpContext.Session.GetObject<Cart>("mycart");
        //    var y =await _context.Order.ToListAsync();
        //    var z = _usermanager.GetUserName(HttpContext.User);
        //    var user = _context.Customer.Where(c => c.CustomerName == z).FirstOrDefaultAsync();            
        //    foreach (var item in x.Books)
        //    {
        //        orderbooks.Add(item);
        //        foreach (var odr in y)
        //        {
        //            odr.BookId = item.Id;
        //            odr.CustomerId = user.Id;
        //            odr.VendorId = item.VendorId.Value;
        //            odr.Quantity = item.Quantity.Value;
        //            odr.SubTotal = item.Price * item.Quantity.Value;
        //            odr.BkashNumber = bkash;
        //            odr.TransactionCode = trcode;
        //            odr.ShippingAddress = SA;
        //            if (odr != null)
        //            {
        //                _context.Order.Add(odr);
        //                await _context.SaveChangesAsync();
        //            }
        //            else
        //            {
        //                return Content("Error");
        //            }
        //        }
        //    }
            
        //    return View(orderbooks);
        //}

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var book = await _context.Book.FindAsync(id);
            _context.Book.Remove(book);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookExists(int id)
        {
            return _context.Book.Any(e => e.Id == id);
        }
    }
}
