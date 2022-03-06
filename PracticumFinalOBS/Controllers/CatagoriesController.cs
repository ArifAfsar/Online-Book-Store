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
    public class CatagoriesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _usermanager;

        public CatagoriesController(ApplicationDbContext context,UserManager<IdentityUser> usermanager)
        {
            _usermanager = usermanager;
            _context = context;
        }

        // GET: Catagories
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Catagory.Include(c => c.Admin);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Catagories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catagory = await _context.Catagory
                .Include(c => c.Admin)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (catagory == null)
            {
                return NotFound();
            }

            return View(catagory);
        }

        // GET: Catagories/Create
        public IActionResult Create()
        {
            ViewData["AdminId"] = new SelectList(_context.Admin, "Id", "ConfirmPassword");
            return View();
        }

        // POST: Catagories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CatagoryName,AdminId")] Catagory catagory)
        {
            if (ModelState.IsValid)
            {
                var r = _usermanager.GetUserName(HttpContext.User);
                var target = await _context.Admin.Where(c => c.Email == r).FirstOrDefaultAsync();
                catagory.AdminId = target.Id;
                _context.Add(catagory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AdminId"] = new SelectList(_context.Admin, "Id", "ConfirmPassword", catagory.AdminId);
            return View(catagory);
        }

        // GET: Catagories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catagory = await _context.Catagory.FindAsync(id);
            if (catagory == null)
            {
                return NotFound();
            }
            ViewData["AdminId"] = new SelectList(_context.Admin, "Id", "ConfirmPassword", catagory.AdminId);
            return View(catagory);
        }

        // POST: Catagories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CatagoryName,AdminId")] Catagory catagory)
        {
            if (id != catagory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(catagory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatagoryExists(catagory.Id))
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
            ViewData["AdminId"] = new SelectList(_context.Admin, "Id", "ConfirmPassword", catagory.AdminId);
            return View(catagory);
        }

        // GET: Catagories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catagory = await _context.Catagory
                .Include(c => c.Admin)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (catagory == null)
            {
                return NotFound();
            }

            return View(catagory);
        }

        // POST: Catagories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var catagory = await _context.Catagory.FindAsync(id);
            var samecata = await _context.Book.Where(n=>n.CatagoryId==id).ToListAsync();
            samecata.ForEach(n => n.Catagory = null);
            foreach(var i in samecata)
            {
                _context.Update(i);
                await _context.SaveChangesAsync();
            }
            _context.Catagory.Remove(catagory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CatagoryExists(int id)
        {
            return _context.Catagory.Any(e => e.Id == id);
        }
    }
}
