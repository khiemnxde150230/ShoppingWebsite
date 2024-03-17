namespace ShoppingWebsite.Models
{
    public partial class OrderDetails
    {
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }

        public virtual Orders Orders { get; set; } = null!;
        public virtual Products Products { get; set; } = null!;
    }
}
