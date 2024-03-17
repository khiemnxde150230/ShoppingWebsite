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

namespace ShoppingWebsite.Pages.Components.Supplier
{
    public class EditModel : PageModel
    {
        private readonly ShoppingWebsite.Data.ApplicationDBContext _context;

        public EditModel(ShoppingWebsite.Data.ApplicationDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public SupplierVM supplierVM { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Suppliers == null)
            {
                return NotFound();
            }

            supplierVM = await _context.Suppliers.Where(s => s.SupplierID == id)
                            .Select(s => new SupplierVM
                            {
                                SupplierID = s.SupplierID,
                                CompanyName = s.CompanyName,
                                Address = s.Address,
                                Phone = s.Phone
                            }).FirstOrDefaultAsync();

            if (supplierVM == null)
            {
                return NotFound();
            }
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

            var suppliersToUpdate = await _context.Suppliers.FindAsync(id);

            if (suppliersToUpdate == null)
            {
                return NotFound();
            }

            suppliersToUpdate.CompanyName = supplierVM.CompanyName;
            suppliersToUpdate.Address = supplierVM.Address;
            suppliersToUpdate.Phone = supplierVM.Phone;

            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
