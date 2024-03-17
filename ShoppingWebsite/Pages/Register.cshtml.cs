using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShoppingWebsite.Data;
using ShoppingWebsite.Models;
using System.Diagnostics.Metrics;

namespace ShoppingWebsite.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly ApplicationDBContext _context;

        public RegisterModel(ApplicationDBContext context)
        {
            _context = context;
        }

        public string errorMess { get; set; }
        public IActionResult OnPost(string fullname, string username, string address, string phone, string password)
        {
            var checkAccount = checkUserName(username);
            var checkCustomer = checkContactAPhone(username, phone);
            var account = new Account
            {
                FullName = fullname,
                UserName = username,
                Password = password,
                Type = 2
            };
            var customer = new Customers
            {
                Password= password,
                ContactName= username,
                Address= address,
                Phone= phone
            };

            if (checkAccount == null && checkCustomer == null)
            {
                _context.Accounts.Add(account);
                _context.Customers.Add(customer);
                _context.SaveChanges();
                return RedirectToPage("Login");
            }
            else
            {
                errorMess = "The customer already exist.";
                return Page();
            }
        }

        private Account checkUserName(string userName)
        {
            Account account = _context.Accounts.SingleOrDefault(a => a.UserName.Equals(userName));
            if (account != null)
            {
                return account;
            }
            return null;
        }

        private Customers checkContactAPhone(string contactname, string phone)
        {
            Customers customers = _context.Customers.SingleOrDefault(c => c.ContactName.Equals(contactname) && c.Phone.Equals(phone));
            if (customers != null)
            {
                return customers;
            }
            return null;
        }
    }
}
