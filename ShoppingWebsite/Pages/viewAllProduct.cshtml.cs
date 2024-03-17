using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ShoppingWebsite.Data;
using ShoppingWebsite.Models;
using System.Diagnostics;

namespace ShoppingWebsite.Pages
{
    public class viewAllProductModel : PageModel
    {
        private readonly ApplicationDBContext _context;

        public viewAllProductModel(ApplicationDBContext context)
        {
            _context = context;
        }
        public IList<Products> listPizza { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Products != null)
            {
                listPizza = await _context.Products
                .Include(p => p.Categories)
                .Include(p => p.Suppliers).ToListAsync();
            }
        }
    }
}
