namespace CoffeeShopAPI.Dtos.CustomerPreference
{
    public class CustomerPreferenceWithAllDto
    {
        public int Id { get; set; }
        public string? Preference { get; set; }
        public int CustomerId { get; set; }
    }
}
