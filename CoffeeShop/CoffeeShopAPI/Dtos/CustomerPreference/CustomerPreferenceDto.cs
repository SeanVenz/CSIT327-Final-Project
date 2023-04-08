using System.ComponentModel.DataAnnotations;

namespace CoffeeShopAPI.Dtos.CustomerPreference
{
    public class CustomerPreferenceDto
    {
        [Required(ErrorMessage = "Customer Preferencee is Required")]
        [MaxLength(100, ErrorMessage = "The maximum length for the Preference of Customer is 100 characters")]
        public string? Preference { get; set; }
    }
}
