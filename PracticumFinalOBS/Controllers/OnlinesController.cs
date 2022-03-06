using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PracticumFinalOBS.Data;
using PracticumFinalOBS.Models;

namespace PracticumFinalOBS.Controllers
{
    public class OnlinesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _henv;

        public OnlinesController(ApplicationDbContext context, IWebHostEnvironment henv)
        {
            _henv = henv;
            _context = context;
        }

        // GET: Onlines
        public async Task<IActionResult> Index()
        {
            return View(await _context.Online.ToListAsync());
        }

        // GET: Onlines/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var online = await _context.Online
                .FirstOrDefaultAsync(m => m.Id == id);
            if (online == null)
            {
                return NotFound();
            }

            return View(online);
        }

        // GET: Onlines/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Onlines/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Author")] Online online,IFormFile Image,IFormFile pdf)
        {
            if (ModelState.IsValid)
            {
                if(Image != null)
                {
                    var root = _henv.WebRootPath;
                    var dir = "EBook";
                    var fname = Path.GetFileName(Image.FileName);
                    var filename = Path.Combine(root , dir, fname);
                    using(var stream = new FileStream(filename, FileMode.Create))
                    {
                        await Image.CopyToAsync(stream);
                    }
                    online.Image = fname;
                }
                else
                {
                    online.Image = "-";
                }
                if (pdf != null)
                {
                    var root = _henv.WebRootPath;
                    var dir = "PDF";
                    var fname = Path.GetFileName(pdf.FileName);
                    var filename = Path.Combine(root, dir, fname);
                    using (var stream = new FileStream(filename, FileMode.Create))
                    {
                        await pdf.CopyToAsync(stream);
                    }
                    online.pdf = fname;
                }
                else
                {
                    online.pdf = "-";
                }

                _context.Add(online);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(online);
        }

        // GET: Onlines/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var online = await _context.Online.FindAsync(id);
            if (online == null)
            {
                return NotFound();
            }
            return View(online);
        }

        // POST: Onlines/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Author,Image,pdf")] Online online)
        {
            if (id != online.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(online);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OnlineExists(online.Id))
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
            return View(online);
        }

        // GET: Onlines/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var online = await _context.Online
                .FirstOrDefaultAsync(m => m.Id == id);
            if (online == null)
            {
                return NotFound();
            }

            return View(online);
        }

        // POST: Onlines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var online = await _context.Online.FindAsync(id);
            _context.Online.Remove(online);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OnlineExists(int id)
        {
            return _context.Online.Any(e => e.Id == id);
        }
    }
}
