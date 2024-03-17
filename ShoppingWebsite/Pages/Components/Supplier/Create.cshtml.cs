using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShoppingWebsite.Data;
using ShoppingWebsite.Models;
using ShoppingWebsite.ViewModels;

namespace ShoppingWebsite.Pages.Components.Supplier
{
    public class CreateModel : PageModel
    {
        private readonly ShoppingWebsite.Data.ApplicationDBContext _context;

        public CreateModel(ShoppingWebsite.Data.ApplicationDBContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetString("username") is null) { return RedirectToPage("/Login"); }
            var authenticated = HttpContext.Session.GetInt32("type");
            if (authenticated == 2) { return RedirectToPage("/Login"); }
            return Page();
        }

        [BindProperty]
        public SupplierVM supplierVM { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            var entry = _context.Add(new Suppliers());
            entry.CurrentValues.SetValues(supplierVM);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
