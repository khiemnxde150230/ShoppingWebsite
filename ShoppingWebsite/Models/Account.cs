namespace ShoppingWebsite.Models
{
    public partial class Account
    {
        public int AccountID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public int Type { get; set; }
    }
}
