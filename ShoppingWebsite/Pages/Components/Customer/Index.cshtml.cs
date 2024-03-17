using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ShoppingWebsite.Data;
using ShoppingWebsite.Models;

namespace ShoppingWebsite.Pages.Components.Customer
{
    public class IndexModel : PageModel
    {
        private readonly ShoppingWebsite.Data.ApplicationDBContext _context;

        public IndexModel(ShoppingWebsite.Data.ApplicationDBContext context)
        {
            _context = context;
        }

        public IList<Customers> Customers { get;set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            if (HttpContext.Session.GetString("username") is null) { return RedirectToPage("/Login"); }
            var authenticated = HttpContext.Session.GetInt32("type");
            if (authenticated == 2) { return RedirectToPage("/Login"); }
            if (_context.Customers != null)
            {
                Customers = await _context.Customers.ToListAsync();
            }
            return Page();
        }
    }
}
