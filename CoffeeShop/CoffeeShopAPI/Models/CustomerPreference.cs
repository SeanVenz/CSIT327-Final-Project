namespace CoffeeShopAPI.Models
{
    public class CustomerPreference
    {
        public int Id { get; set; }
        public string? Preference { get; set; }
        public int CustomerId { get; set; }

    }
}
