namespace CoffeeShopAPI.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public List<CustomerPreference> CustomerPrefence { get; set; } = new List<CustomerPreference>();
    }
}
