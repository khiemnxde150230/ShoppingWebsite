using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoppingWebsite.Models;

namespace ShoppingWebsite.ViewComponents
{
    [ViewComponent(Name = "Nav")]
    public class NavViewComponents : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewBag.fullname = HttpContext.Session.GetString("fullname");
            ViewBag.username = HttpContext.Session.GetString("username");
            ViewBag.id = HttpContext.Session.GetInt32("id");
            ViewBag.type = HttpContext.Session.GetInt32("type");
            return View("Index");
        }
    }
}
