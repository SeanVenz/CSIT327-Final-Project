using System.ComponentModel.DataAnnotations;

namespace CoffeeShopAPI.Dtos.CustomerPreference
{
    public class CustomerPreferenceCreationDto
    {
        [Required(ErrorMessage = "Customer Preference is Required")]
        [MaxLength(100, ErrorMessage = "The maximum length for the Prefernece of Customer is 100 characters")]
        public string? Preference { get; set; }

        [Required(ErrorMessage = "Customer Id is Required")]
        public int CustomerId { get; set; }
    }
}
