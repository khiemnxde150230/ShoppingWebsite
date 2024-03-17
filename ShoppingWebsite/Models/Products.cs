﻿namespace ShoppingWebsite.Models
{
    public partial class Products
    {
        public Products()
        {
            OrderDetails = new HashSet<OrderDetails>();
        }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int SupplierID { get; set; }
        public int CategoryID { get; set; }
        public int QuantityPerUnit { get; set; }
        public decimal UnitPrice { get; set; }
        public string ProductImage { get; set;}

        public virtual Suppliers Suppliers { get; set; }
        public virtual Categories Categories { get; set; }
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
