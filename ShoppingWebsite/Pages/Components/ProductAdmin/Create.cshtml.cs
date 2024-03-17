
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShoppingWebsite.Data;
using ShoppingWebsite.Models;
using ShoppingWebsite.ViewModels;

namespace ShoppingWebsite.Pages.Components.ProductAdmin
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDBContext _context;

        public CreateModel(ApplicationDBContext context)
        {
            _context = context;
        }
        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetString("username") is null) { return RedirectToPage("/Login"); }
            var authenticated = HttpContext.Session.GetInt32("type");
            if (authenticated == 2) { return RedirectToPage("/Login"); }
            ViewData["CategoryID"] = new SelectList(_context.Categories, "CategoryID", "CategoryName");
            ViewData["SupplierID"] = new SelectList(_context.Suppliers, "SupplierID", "CompanyName");
            return Page();
        }

        [BindProperty]
        public ProductVM productVM { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }


            var entry = _context.Add(new Products());
            entry.CurrentValues.SetValues(productVM);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
