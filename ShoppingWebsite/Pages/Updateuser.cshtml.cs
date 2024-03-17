using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShoppingWebsite.Models;
using ShoppingWebsite.ViewModels;

namespace ShoppingWebsite.Pages
{
    public class UpdateuserModel : PageModel
    {
        private readonly ShoppingWebsite.Data.ApplicationDBContext _context;
        [BindProperty(Name = "id", SupportsGet = true)]
        public int Id { get; set; }
        public UpdateuserModel(ShoppingWebsite.Data.ApplicationDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Customers customers { get; set; } = default!;
        public void OnGet()
        {
            int id = getCustomerID();
            customers = _context.Customers.Find(id);
        }

        private int getCustomerID()
        {
            Account account = _context.Accounts.Find(Id);
            Customers custom = _context.Customers.SingleOrDefault(c => c.ContactName.Equals(account.UserName));
            if(custom != null)
            {
                return custom.CustomerID;
            }
            return 0;
        }
    }
}
