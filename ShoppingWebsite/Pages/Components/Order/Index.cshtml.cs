using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ShoppingWebsite.Data;
using ShoppingWebsite.Models;

namespace ShoppingWebsite.Pages.Components.Order
{
    public class IndexModel : PageModel
    {
        private readonly ShoppingWebsite.Data.ApplicationDBContext _context;

        public IndexModel(ShoppingWebsite.Data.ApplicationDBContext context)
        {
            _context = context;
        }

        public IList<Orders> Orders { get;set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            if (HttpContext.Session.GetString("username") is null) { return RedirectToPage("/Login"); }
            var authenticated = HttpContext.Session.GetInt32("type");
            if (authenticated == 2) { return RedirectToPage("/Login"); }
            if (_context.Orders != null)
            {
                Orders = await _context.Orders
                .Include(o => o.Customers).ToListAsync();
            }
            return Page();
        }
    }
}
