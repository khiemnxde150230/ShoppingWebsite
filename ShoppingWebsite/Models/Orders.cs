using System.Diagnostics.Metrics;

namespace ShoppingWebsite.Models
{
    public partial class Orders
    {
        public Orders()
        {
            OrderDetails = new HashSet<OrderDetails>();
        }

        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? RequiredDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public decimal? Freight { get; set; }
        public string ShipAddress { get; set; }

        public virtual Customers Customers { get; set; } = null!;

        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
