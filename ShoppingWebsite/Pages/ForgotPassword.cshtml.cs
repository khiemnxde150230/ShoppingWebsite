using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShoppingWebsite.Data;
using ShoppingWebsite.OtherService;

namespace ShoppingWebsite.Pages
{
    public class ForgotPasswordModel : PageModel
    {
        private readonly ApplicationDBContext _context;

        public ForgotPasswordModel(ApplicationDBContext context)
        {
            _context = context;
        }

        public string errorMessage { get; set; }
        public void OnGet()
        {
        }

        public string GenerateRandomString()
        {
            Random random = new Random();
            string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            char[] randomChars = new char[10];
            randomChars[0] = characters[random.Next(26)];
            for (int i = 1; i < 10; i++)
            {
                randomChars[i] = characters[random.Next(characters.Length)];
            }
            string randomString = new string(randomChars);
            return randomString;
        }

        //public async Task<object> ForgotPassword(string email)
        //{
            
        //}

        public async Task<PageResult> OnPost(string username)
        {
            //var check = false;
            var account = _context.Accounts.FirstOrDefault(x => x.UserName.Equals(username));
            if (account == null)
            {
                errorMessage = "Invalid username or password";
                return Page();
            }
            else
            {
                account.Password = GenerateRandomString();
                _context.SaveChanges();
                try
                {
                    await EmailService.Instance.SendMail(account.UserName, 2, account.FullName, account.UserName, account.Password);
                    errorMessage = "Email sended";
                    return Page();
                }
                catch
                {
                    errorMessage = "Send email failed";
                    return Page();
                }

            }
        }
    }
}
