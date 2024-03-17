using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ShoppingWebsite.Data;
using ShoppingWebsite.Models;

namespace ShoppingWebsite.Pages.Components.Supplier
{
    public class IndexModel : PageModel
    {
        private readonly ShoppingWebsite.Data.ApplicationDBContext _context;

        public IndexModel(ShoppingWebsite.Data.ApplicationDBContext context)
        {
            _context = context;
        }

        public IList<Suppliers> Suppliers { get;set; } = default!;

        public async Task<IActionResult> OnGetAsync(string msg)
        {
            if (HttpContext.Session.GetString("username") is null) { return RedirectToPage("/Login"); }
            var authenticated = HttpContext.Session.GetInt32("type");
            if (authenticated == 2) { return RedirectToPage("/Login"); }
            if (_context.Suppliers != null)
            {
                Suppliers = await _context.Suppliers.ToListAsync();
            }
            ViewData["error"] = msg;
            return Page();
        }

        public IActionResult OnGetDelete(int? id)
        {
            var checkSupplier = _context.Products.FirstOrDefault(x => x.SupplierID.Equals(id));

            if (checkSupplier != null)
            {
                string error = "Delete failed: Supplier must not be assigned to any product";
                return RedirectToPage("", new { msg = error });
            }
            var deleteS = _context.Suppliers.Find(id);

            if (deleteS != null)
            {
                _context.Suppliers.Remove(deleteS);

                _context.SaveChanges();
            }

            return RedirectToPage();
        }
    }
}
