using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PracticumFinalOBS.Data;
using PracticumFinalOBS.Models;

namespace PracticumFinalOBS.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _usermanager;
        private readonly RoleManager<IdentityRole> _rolemanager;

        public CustomersController(ApplicationDbContext context, UserManager<IdentityUser> usermanager, RoleManager<IdentityRole> rolemanager)
        {
            _context = context;
            _usermanager = usermanager;
            _rolemanager = rolemanager;
        }

        // GET: Customers
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Customer.Include(c => c.Membership);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Customers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customer
                .Include(c => c.Membership)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // GET: Customers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CustomerName,CustomerEmail,CustomerPassword,ConfirmPassword,CustomerDOB,CustomerAddress,CustomerPhone")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                IdentityUser u = new IdentityUser(customer.CustomerEmail);
                u.Email = customer.CustomerEmail;
                u.EmailConfirmed = true;

                await _usermanager.CreateAsync(u, customer.ConfirmPassword);
                await _usermanager.AddToRoleAsync(u, "Customer");
                customer.Membership = null;
                customer.CustomerPassword = "";
                customer.ConfirmPassword = "";
                _context.Add(customer);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index","Home");
            }
            ViewData["MembershipId"] = new SelectList(_context.Set<Membership>(), "Id", "Description", customer.MembershipId);
            return View(customer);
        }

        // GET: Customers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customer.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            ViewData["MembershipId"] = new SelectList(_context.Set<Membership>(), "Id", "Description", customer.MembershipId);
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CustomerName,CustomerEmail,CustomerPassword,ConfirmPassword,CustomerDOB,CustomerAddress,CustomerPhone,MembershipId")] Customer customer)
        {
            if (id != customer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(customer.Id))
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
            ViewData["MembershipId"] = new SelectList(_context.Set<Membership>(), "Id", "Description", customer.MembershipId);
            return View(customer);
        }

        // GET: Customers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customer
                .Include(c => c.Membership)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customer = await _context.Customer.FindAsync(id);
            _context.Customer.Remove(customer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> BuyMembership(int? id)
        {
            var c = _usermanager.GetUserName(HttpContext.User);
            var customer = await _context.Customer.Where(n=>n.CustomerEmail == c).FirstOrDefaultAsync();
            if (c == null)
            {
                return NotFound();
            }

            if (customer.MembershipId.HasValue)
            {
                return Content("You are already subscribed to an Membership");
            }

            customer.MembershipId = id;
            
            
            customer.MembershipDate = DateTime.Now;
            _context.Update(customer);
            await _context.SaveChangesAsync();
            ViewBag.customer = customer.CustomerName;

            return View("Sub");
        }

        private bool CustomerExists(int id)
        {
            return _context.Customer.Any(e => e.Id == id);
        }
    }
}
