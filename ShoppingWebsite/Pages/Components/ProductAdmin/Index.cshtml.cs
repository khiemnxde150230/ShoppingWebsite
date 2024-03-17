using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ShoppingWebsite.Data;
using ShoppingWebsite.Models;

namespace ShoppingWebsite.Pages.Components.ProductAdmin
{
    public class IndexModel : PageModel
    {
        private readonly ShoppingWebsite.Data.ApplicationDBContext _context;

        public IndexModel(ShoppingWebsite.Data.ApplicationDBContext context)
        {
            _context = context;
        }
        public IList<Products> Products { get;set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            if (HttpContext.Session.GetString("username") is null) { return RedirectToPage("/Login"); }
            var authenticated = HttpContext.Session.GetInt32("type");
            if (authenticated == 2) { return RedirectToPage("/Login"); }
            if (_context.Products != null)
            {
                Products = await _context.Products
                .Include(p => p.Categories)
                .Include(p => p.Suppliers).ToListAsync();            
            }
            return Page();
        }
        public IActionResult OnGetDelete(int? id)
        {
            var deleteP = _context.Products.Find(id);

            if (deleteP != null)
            {
                _context.Products.Remove(deleteP);

                _context.SaveChanges();
            }

            return RedirectToPage();
        }
    }
}
