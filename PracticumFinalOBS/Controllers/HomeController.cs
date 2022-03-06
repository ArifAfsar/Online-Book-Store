using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PracticumFinalOBS.Data;
using PracticumFinalOBS.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PracticumFinalOBS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _context = context;
            _logger = logger;
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

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
