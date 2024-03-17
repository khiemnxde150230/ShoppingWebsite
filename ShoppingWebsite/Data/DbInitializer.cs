using ShoppingWebsite.Models;
using System.Diagnostics;

namespace ShoppingWebsite.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDBContext context)
        {
            context.Database.EnsureCreated();
            // Look for any Accounts.
            if (context.Accounts.Any())
            {
                return;   // DB has been seeded
            }
            var account = new Account[]
            {
            new Account{UserName="admin@gmail.com", Password="a", FullName="Admin", Type=1}
            };
            foreach (Account a in account)
            {
                context.Accounts.Add(a);
            }
            context.SaveChanges();

            // Look for any Categories.
            if (context.Categories.Any())
            {
                return;   // DB has been seeded
            }
            var category = new Categories[]
            {
            new Categories{CategoryName="Fruit", Description="Sweet and fresh"},
            new Categories{CategoryName="Food", Description="Full of nutrients"}
            };
            foreach (Categories c in category)
            {
                context.Categories.Add(c);
            }
            context.SaveChanges();

            // Look for any Suppliers.
            if (context.Suppliers.Any())
            {
                return;   // DB has been seeded
            }
            var supplier = new Suppliers[]
            {
            new Suppliers{CompanyName="Produce Marketing Association", Address="New York", Phone="610-296-2850"},
            new Suppliers{CompanyName="Fruit and Vegetable Suppliers Directories", Address="Chicago", Phone="210-296-2850"},
            new Suppliers{CompanyName="Local Chamber of Commerce", Address="Boston", Phone="410-276-2850"},
            new Suppliers{CompanyName="Online search engines", Address="San Francisco", Phone="820-444-2850"}
            };
            foreach (Suppliers s in supplier)
            {
                context.Suppliers.Add(s);
            }
            context.SaveChanges();

            // Look for any products.
            if (context.Products.Any())
            {
                return;   // DB has been seeded
            }

            var product = new Products[]
            {
            new Products{ProductName="Berries", SupplierID=4, CategoryID=1 ,QuantityPerUnit=50, UnitPrice=20000,ProductImage="https://e0.pxfuel.com/wallpapers/1006/511/desktop-wallpaper-strawberries-raspberries-blueberries-cherries-basket-u-pixelz-fruit.jpg"},
            new Products{ProductName="Citrus Fruits", SupplierID=3, CategoryID=1 ,QuantityPerUnit=150, UnitPrice=40000,ProductImage="https://img5.goodfon.com/wallpaper/nbig/9/cd/wood-blue-background-fruits-colorful-citrus-tsitrus-frukty.jpg"},
            new Products{ProductName="Tropical Fruits", SupplierID=2, CategoryID=1 ,QuantityPerUnit=250, UnitPrice=60000,ProductImage="https://plus.unsplash.com/premium_photo-1661277691826-fe20b02cfc70?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxzZWFyY2h8MXx8dHJvcGljYWwlMjBmcnVpdHxlbnwwfHwwfHw%3D&w=1000&q=80"},
            new Products{ProductName="Stone Fruits", SupplierID=1, CategoryID=1 ,QuantityPerUnit=350, UnitPrice=80000,ProductImage="https://hips.hearstapps.com/hmg-prod/images/festive-season-royalty-free-image-180383152-1552929403.jpg"},
            new Products{ProductName="Pome Fruits", SupplierID=1, CategoryID=1 ,QuantityPerUnit=450, UnitPrice=100000,ProductImage="https://www.teahub.io/photos/full/245-2456354_fruits-and-vegetables.jpg"},
            new Products{ProductName="Melons", SupplierID=3, CategoryID=1 ,QuantityPerUnit=550, UnitPrice=25000,ProductImage="https://c4.wallpaperflare.com/wallpaper/128/736/42/watermelon-fresh-wood-slices-watermelon-hd-wallpaper-preview.jpg"},
            new Products{ProductName="Dried Fruits", SupplierID=2, CategoryID=1 ,QuantityPerUnit=650, UnitPrice=30000,ProductImage="https://c4.wallpaperflare.com/wallpaper/108/532/862/table-bowl-nuts-spices-dried-fruits-hd-wallpaper-preview.jpg"},
            new Products{ProductName="Hamburger", SupplierID=4, CategoryID=2 ,QuantityPerUnit=750, UnitPrice=50000,ProductImage="https://c4.wallpaperflare.com/wallpaper/197/854/431/fire-burger-5k-steak-wallpaper-preview.jpg"},
            new Products{ProductName="Hot dogs", SupplierID=4, CategoryID=2 ,QuantityPerUnit=850, UnitPrice=90000,ProductImage="https://us.123rf.com/450wm/altitudevisual/altitudevisual2212/altitudevisual221206754/195463275-hotdog-with-sausage-drenched-in-juicy-mayonnaise-sauce-and-spices.jpg?ver=6"},
            new Products{ProductName="Barbecue", SupplierID=3, CategoryID=2 ,QuantityPerUnit=950, UnitPrice=80000,ProductImage="https://wallpaperaccess.com/full/2269580.jpg"},
            new Products{ProductName="Fried chicken", SupplierID=2, CategoryID=2 ,QuantityPerUnit=250, UnitPrice=100000,ProductImage="https://img.freepik.com/free-photo/crispy-fried-chicken-plate-with-salad-carrot_1150-20212.jpg"},
            new Products{ProductName="Pizza", SupplierID=1, CategoryID=2 ,QuantityPerUnit=80, UnitPrice=75000,ProductImage="https://images6.alphacoders.com/609/609345.jpg"},
            };
            foreach (Products p in product)
            {
                context.Products.Add(p);
            }
            context.SaveChanges();
        }
    }
}
