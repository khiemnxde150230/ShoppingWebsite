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

namespace ShoppingWebsite.Pages.Components.Category
{
    public class EditModel : PageModel
    {
        private readonly ShoppingWebsite.Data.ApplicationDBContext _context;

        public EditModel(ShoppingWebsite.Data.ApplicationDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CategoryVM categoryVM { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Categories == null)
            {
                return NotFound();
            }

            categoryVM = await _context.Categories.Where(s => s.CategoryID == id)
                .Select(s => new CategoryVM
                {
                    CategoryID = s.CategoryID,
                    CategoryName = s.CategoryName,
                    Description = s.Description
                }).FirstOrDefaultAsync();

            if (categoryVM == null)
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

            var categoryToUpdate = await _context.Categories.FindAsync(id);

            if (categoryToUpdate == null)
            {
                return NotFound();
            }

            categoryToUpdate.CategoryName = categoryVM.CategoryName;
            categoryToUpdate.Description = categoryVM.Description;

            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
