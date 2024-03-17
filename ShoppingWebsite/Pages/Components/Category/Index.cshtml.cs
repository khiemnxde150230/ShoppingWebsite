using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ShoppingWebsite.Data;
using ShoppingWebsite.Models;

namespace ShoppingWebsite.Pages.Components.Category
{
    public class IndexModel : PageModel
    {
        private readonly ShoppingWebsite.Data.ApplicationDBContext _context;

        public IndexModel(ShoppingWebsite.Data.ApplicationDBContext context)
        {
            _context = context;
        }

        public IList<Categories> Categories { get;set; } = default!;

        public async Task<IActionResult> OnGetAsync(string msg)
        {
            if (HttpContext.Session.GetString("username") is null) { return RedirectToPage("/Login"); }
            var authenticated = HttpContext.Session.GetInt32("type");
            if (authenticated == 2) { return RedirectToPage("/Login"); }
            if (_context.Categories != null)
            {
                Categories = await _context.Categories.ToListAsync();
            }
            ViewData["error"] = msg;
            return Page();
        }

        public IActionResult OnGetDelete(int? id)
        {
            var checkCategory = _context.Products.FirstOrDefault(prod => prod.CategoryID.Equals(id));

            if (checkCategory != null)
            {
                string error = "Delete failed: Category must not be assigned to any product";
                return RedirectToPage("", new { msg = error });
            }
            var deleteC = _context.Categories.Find(id);

            if (deleteC != null)
            {
                _context.Categories.Remove(deleteC);

                _context.SaveChanges();
            }

            return RedirectToPage();
        }
    }
}
