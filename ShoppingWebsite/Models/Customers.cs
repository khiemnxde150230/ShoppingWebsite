namespace ShoppingWebsite.Models
{
    public partial class Customers
    {
        public Customers()
        {
            Orders = new HashSet<Orders>();
        }
        public int CustomerID { get; set; }
        public string Password { get; set; }
        public string ContactName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }
    }
}
