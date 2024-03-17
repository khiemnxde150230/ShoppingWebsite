using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShoppingWebsite.Data;
using ShoppingWebsite.Models;
using ShoppingWebsite.ViewModels;

namespace ShoppingWebsite.Pages.Components.ProductAdmin
{
    public class EditModel : PageModel
    {
        private readonly ShoppingWebsite.Data.ApplicationDBContext _context;

        public EditModel(ShoppingWebsite.Data.ApplicationDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ProductVM productVM { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            productVM = await _context.Products.Where(s => s.ProductID == id)
                .Select(s => new ProductVM
                {
                    ProductID = s.ProductID,
                    ProductName = s.ProductName,
                    SupplierID = s.SupplierID,
                    CategoryID = s.CategoryID,
                    QuantityPerUnit = s.QuantityPerUnit,
                    UnitPrice = s.UnitPrice,
                    ProductImage = s.ProductImage
                }).FirstOrDefaultAsync();

            if (productVM == null)
            {
                return NotFound();
            }
            ViewData["CategoryID"] = new SelectList(_context.Categories, "CategoryID", "CategoryName");
           ViewData["SupplierID"] = new SelectList(_context.Suppliers, "SupplierID", "CompanyName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var productToUpdate = await _context.Products.FindAsync(id);

            if (productToUpdate == null)
            {
                return NotFound();
            }

            productToUpdate.ProductName = productVM.ProductName;
            productToUpdate.SupplierID = productVM.SupplierID;
            productToUpdate.CategoryID = productVM.CategoryID;
            productToUpdate.QuantityPerUnit = productVM.QuantityPerUnit;
            productToUpdate.UnitPrice = productVM.UnitPrice;
            productToUpdate.ProductImage = productVM.ProductImage;

            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
