namespace ShoppingWebsite.Models
{
    public partial class Suppliers
    {
        public Suppliers()
        {
            Products = new HashSet<Products>();
        }
        public int SupplierID { get; set; }
        public string CompanyName { get; set;}
        public string Address { get; set;}
        public string Phone { get; set;}

        public virtual ICollection<Products> Products { get; set; }
    }
}
