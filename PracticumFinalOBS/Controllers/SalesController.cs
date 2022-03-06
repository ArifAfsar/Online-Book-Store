using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PracticumFinalOBS.Data;
using PracticumFinalOBS.Models;

namespace PracticumFinalOBS.Controllers
{
    public class SalesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SalesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Sales
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Sales.Include(s => s.Book).Include(s => s.Customer).Include(s => s.Vendor);
            return View(await applicationDbContext.OrderByDescending(n=>n.SaleDate).ToListAsync());
        }

        // GET: Sales/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sales = await _context.Sales
                .Include(s => s.Book)
                .Include(s => s.Customer)
                .Include(s => s.Vendor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sales == null)
            {
                return NotFound();
            }

            return View(sales);
        }

        // GET: Sales/Create
   
        public async Task<IActionResult> Create(string invoice)
        {
            if(string.IsNullOrEmpty(invoice))
            {
                return NotFound();
            }
            
            var order =await _context.Order.Where(n=>n.InvoiceNo == invoice).ToListAsync();
            List<Sales> sllist = new List<Sales>();
            foreach (var item in order)
            {
                Sales x = new Sales();
                x.BookId = item.BookId;
                x.Quantity = item.Quantity;
                x.SubTotal = item.SubTotal;
                x.VendorId = item.VendorId;
                x.CustomerId = item.CustomerId;
                x.SaleDate = DateTime.Now;
                _context.Sales.Add(x);
                await _context.SaveChangesAsync();

                _context.Order.Remove(item);
                await _context.SaveChangesAsync();
                //Update Book Quantity
                var book = _context.Book.Where(b => b.Id == x.BookId).FirstOrDefault();
                book.NOB -= ((int)item.Quantity);
                //Delete Book If Quantity Reaches Zero
                
                _context.Update(book);
                await _context.SaveChangesAsync();
                //var nulbok = await _context.Book.Where(n=>n.NOB == 0).FirstOrDefaultAsync();
                //if (nulbok !=null)
                //{
                //    _context.Book.Remove(nulbok);
                //    await _context.SaveChangesAsync();
                //}
            }
            return RedirectToAction("Index","Home");
        }

        // GET: Sales/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sales = await _context.Sales.FindAsync(id);
            if (sales == null)
            {
                return NotFound();
            }
            ViewData["BookId"] = new SelectList(_context.Book, "Id", "AuthorName", sales.BookId);
            ViewData["CustomerId"] = new SelectList(_context.Customer, "Id", "ConfirmPassword", sales.CustomerId);
            ViewData["VendorId"] = new SelectList(_context.Vendor, "Id", "VendorEmail", sales.VendorId);
            return View(sales);
        }

        // POST: Sales/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BookId,CustomerId,VendorId,Quantity,SubTotal")] Sales sales)
        {
            if (id != sales.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sales);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SalesExists(sales.Id))
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
            ViewData["BookId"] = new SelectList(_context.Book, "Id", "AuthorName", sales.BookId);
            ViewData["CustomerId"] = new SelectList(_context.Customer, "Id", "ConfirmPassword", sales.CustomerId);
            ViewData["VendorId"] = new SelectList(_context.Vendor, "Id", "VendorEmail", sales.VendorId);
            return View(sales);
        }

        // GET: Sales/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sales = await _context.Sales
                .Include(s => s.Book)
                .Include(s => s.Customer)
                .Include(s => s.Vendor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sales == null)
            {
                return NotFound();
            }

            return View(sales);
        }

        // POST: Sales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sales = await _context.Sales.FindAsync(id);
            _context.Sales.Remove(sales);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SalesExists(int id)
        {
            return _context.Sales.Any(e => e.Id == id);
        }
    }
}
