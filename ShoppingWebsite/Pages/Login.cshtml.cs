using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShoppingWebsite.Data;
using ShoppingWebsite.Models;

namespace ShoppingWebsite.Pages
{
    public class LoginModel : PageModel
    {
        private readonly ApplicationDBContext _context;

        public LoginModel(ApplicationDBContext context)
        {
            _context = context;
        }

        public string errorMessage { get; set; }

        public IActionResult OnGetLogout()
        {
            HttpContext.Session.Remove("username");
            HttpContext.Session.Remove("fullname");
            HttpContext.Session.Remove("type");
            HttpContext.Session.Remove("id");
            ViewData["username"] = null;
            return Page();
        }
        public IActionResult OnPost(string username, string password)
        {
            var account = Login(username, password);
            if (account != null)
            {
                HttpContext.Session.SetString("username", username);
                HttpContext.Session.SetString("fullname", account.FullName);
                HttpContext.Session.SetInt32("type", account.Type);
                HttpContext.Session.SetInt32("id", account.AccountID);
                return RedirectToPage("Index");
            }
            else
            {
                errorMessage = "Invalid username or password";
                return Page();
            }
        }
        private Account Login(string username, string password)
        {
            Account account = _context.Accounts.SingleOrDefault(a => a.UserName.Equals(username) && a.Password.Equals(password));
            if (account != null)
            {
               return account;

            }
            return null;
        }
    }
}
