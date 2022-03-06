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
    public class VendorsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _usermanager;
        private readonly RoleManager<IdentityRole> _rolemanager;

        public VendorsController(ApplicationDbContext context,UserManager<IdentityUser> usermanager,RoleManager<IdentityRole> rolemanager)
        {
            _usermanager = usermanager;
            _rolemanager = rolemanager;
            _context = context;
        }
        public async Task<IActionResult> ApprovedVendors(string vend)
        {
            if (string.IsNullOrEmpty(vend))
            {
                vend = "";
            }
            var appvendor = await _context.Vendor.Where(n => n.Status == true).ToListAsync();
            var result = from n in appvendor
                         where n.VendorName.ToUpper()
                         .Contains(vend.ToUpper())
                         select n;
            ViewBag.Vend = vend;
            return View(result);
        }

        public async Task<IActionResult> Inventory()
        {
            var user = User.Identity.Name;
            var vend = await _context.Vendor.Where(x=>x.VendorEmail == user).FirstOrDefaultAsync();
            var result = _context.Book.Where(n => n.VendorId == vend.Id).ToList();
            return View(result);
        }

        public async Task<IActionResult> Sale()
        {
            var u = User.Identity.Name;
            var v =await _context.Vendor.Where(x => x.VendorEmail == u).FirstOrDefaultAsync();
            var salelist =await _context.Sales.Include(s => s.Book).Include(s => s.Customer).Where(n => n.VendorId == v.Id).ToListAsync();
            return View(salelist);
        }

        public IActionResult PendingVendors()
        {
            var pendingvendors = _context.Vendor.Where(m => m.Status == false);
            return View(pendingvendors);
        }

        public async Task<IActionResult> ReviewVendors(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vendor = await _context.Vendor.Where(n => n.Id == id).FirstOrDefaultAsync();
            if (vendor == null)
            {
                return NotFound();
            }

            IdentityUser u = new IdentityUser(vendor.VendorEmail);
            u.Email = vendor.VendorEmail;
            u.EmailConfirmed = true;

            await _usermanager.CreateAsync(u, vendor.VendorPassword);
            await _usermanager.AddToRoleAsync(u, "Vendor");

            vendor.VendorPassword = "";
            vendor.ConfirmPassword = "";
            vendor.Status = true;
            _context.Update(vendor);
            await _context.SaveChangesAsync();
            return View(vendor);

        }

        // GET: Vendors
        public async Task<IActionResult> Index()
        {
            return View(await _context.Vendor.ToListAsync());
        }

        // GET: Vendors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vendor = await _context.Vendor
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vendor == null)
            {
                return NotFound();
            }

            return View(vendor);
        }

        // GET: Vendors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Vendors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,VendorName,VendorEmail,VendorPassword,ConfirmPassword,VendorPhone,DOB,VendorCompany")] Vendor vendor)
        {
            if (ModelState.IsValid)
            {
                ViewBag.name = vendor.VendorName;
                _context.Add(vendor);
                await _context.SaveChangesAsync();
                return View("Notify");
            }
            return View(vendor);
        }

        // GET: Vendors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vendor = await _context.Vendor.FindAsync(id);
            if (vendor == null)
            {
                return NotFound();
            }
            return View(vendor);
        }

        // POST: Vendors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,VendorName,VendorEmail,VendorPassword,ConfirmPassword,VendorPhone,DOB,VendorCompany,Status")] Vendor vendor)
        {
            if (id != vendor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vendor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VendorExists(vendor.Id))
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
            return View(vendor);
        }

        // GET: Vendors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vendor = await _context.Vendor
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vendor == null)
            {
                return NotFound();
            }

            return View(vendor);
        }

        // POST: Vendors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vendor = await _context.Vendor.FindAsync(id);
            _context.Vendor.Remove(vendor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VendorExists(int id)
        {
            return _context.Vendor.Any(e => e.Id == id);
        }
    }
}
