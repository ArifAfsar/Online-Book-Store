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
    public class AdminsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _usermanager;
        private readonly RoleManager<IdentityRole> _rolemanager;

        public AdminsController(ApplicationDbContext context,UserManager<IdentityUser> usermanager,RoleManager<IdentityRole> rolemanager)
        {
            _rolemanager = rolemanager;
            _usermanager = usermanager;
            _context = context;
        }

        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateRole(string approle)
        {
            string msg = "";
            if (approle != null)
            {
                bool exists = await _rolemanager.RoleExistsAsync(approle);
                if (!exists)
                {
                    IdentityRole r = new IdentityRole(approle);
                    await _rolemanager.CreateAsync(r);
                    msg = "Role [" + approle + "] has been created successfully";
                }
                else
                {
                    msg = "Role [" + approle + "] already exists";
                }
            }
            ViewBag.msg = msg;
            return View();
        }

        // GET: Admins
        public async Task<IActionResult> Index()
        {
            return View(await _context.Admin.ToListAsync());
        }

        // GET: Admins/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var admin = await _context.Admin
                .FirstOrDefaultAsync(m => m.Id == id);
            if (admin == null)
            {
                return NotFound();
            }

            return View(admin);
        }

        // GET: Admins/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admins/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Email,Password,ConfirmPassword,Contact")] Admin admin)
        {
            if (ModelState.IsValid)
            {
                IdentityUser u = new IdentityUser(admin.Email);
                u.Email = admin.Email;
                u.EmailConfirmed = true;

                await _usermanager.CreateAsync(u,admin.Password);
                await _usermanager.AddToRoleAsync(u, "Admin");

                admin.Password = "";
                admin.ConfirmPassword = "";

                _context.Add(admin);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(admin);
        }

        // GET: Admins/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var x = _usermanager.GetUserName(HttpContext.User);
            var target = await _context.Admin.Where(c => c.Email == x).FirstOrDefaultAsync();
            if (id != target.Id)
            {
                return NotFound();
            }

            var admin = await _context.Admin.FindAsync(id);
            if (admin == null)
            {
                return NotFound();
            }
            return View(admin);
        }

        // POST: Admins/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Email,Contact")] Admin admin)
        {
            
            if (id != admin.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    
                    _context.Update(admin);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdminExists(admin.Id))
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
            return View(admin);
        }

        // GET: Admins/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var admin = await _context.Admin
                .FirstOrDefaultAsync(m => m.Id == id);
            if (admin == null)
            {
                return NotFound();
            }

            return View(admin);
        }
        // POST: Admins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var admin = await _context.Admin.FindAsync(id);
            _context.Admin.Remove(admin);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdminExists(int id)
        {
            return _context.Admin.Any(e => e.Id == id);
        }
    }
}
