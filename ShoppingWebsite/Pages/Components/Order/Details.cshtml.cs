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
    public class DetailsModel : PageModel
    {
        private readonly ShoppingWebsite.Data.ApplicationDBContext _context;

        public DetailsModel(ShoppingWebsite.Data.ApplicationDBContext context)
        {
            _context = context;
        }

      public Orders Orders { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Orders == null)
            {
                return NotFound();
            }

            var orders = await _context.Orders.FirstOrDefaultAsync(m => m.OrderID == id);
            if (orders == null)
            {
                return NotFound();
            }
            else 
            {
                Orders = orders;
            }
            return Page();
        }
    }
}
