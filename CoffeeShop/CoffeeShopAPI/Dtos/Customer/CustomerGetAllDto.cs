using CoffeeShopAPI.Dtos.CustomerPreference;

namespace CoffeeShopAPI.Dtos.Customer;

public class CustomerGetAllDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Address { get; set; }
    public string? PhoneNumber { get; set; }
    public List<CustomerPreferenceWithAllDto> CustomerPrefence { get; set; } = new List<CustomerPreferenceWithAllDto>();
}
