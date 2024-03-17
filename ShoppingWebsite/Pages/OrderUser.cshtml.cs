using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShoppingWebsite.Data;
using ShoppingWebsite.Models;

namespace ShoppingWebsite.Pages
{
    public class OrderUserModel : PageModel
    {
        private readonly ApplicationDBContext _context;

        [BindProperty(Name = "id", SupportsGet = true)]
        public int Id { get; set; }

        public Products product { get; set; }
        public OrderUserModel(ApplicationDBContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetString("username") is null) { return RedirectToPage("/Login"); }
            product = _context.Products.Find(Id);
            return Page();
        }

        public IActionResult OnPost(int productId, int orderQuantity)
        {
            var username = HttpContext.Session.GetString("username");

            if (username == null) return RedirectToPage("login");
            var customersContact = HttpContext.Session.GetString("username");
            Customers custom= checkContact(customersContact);

            var checkproduct = _context.Products.Find(productId);
            if (checkproduct.QuantityPerUnit > 0 && custom != null) {
                var order = new Orders()
                {
                    CustomerID = custom.CustomerID,
                    OrderDate = DateTime.Now,
                    RequiredDate = DateTime.Now,
                    ShippedDate = DateTime.Now,
                    Freight = 10000,
                    ShipAddress = custom.Address
                };



                _context.Orders.Add(order);
                _context.SaveChanges();

                var orderDetails = new OrderDetails()
                {
                    OrderID = order.OrderID,
                    ProductID = productId,
                    Quantity = orderQuantity,
                    UnitPrice = (decimal)(checkproduct.UnitPrice * orderQuantity + order.Freight)
                };

                _context.OrderDetails.Add(orderDetails);
                checkproduct.QuantityPerUnit -= orderQuantity;
                _context.SaveChanges();               
            }
            return RedirectToPage("viewAllProduct");

        }

        private Customers checkContact(string contactname)
        {
            Customers customers = _context.Customers.SingleOrDefault(c => c.ContactName.Equals(contactname));
            if (customers != null)
            {
                return customers;
            }
            return null;
        }
    }
}
