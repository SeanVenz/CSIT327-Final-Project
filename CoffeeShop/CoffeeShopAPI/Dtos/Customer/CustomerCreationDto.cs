using System.ComponentModel.DataAnnotations;

namespace CoffeeShopAPI.Dtos.Customer
{
    public class CustomerCreationDto
    {
        [Required(ErrorMessage = "Customer Name is Required")]
        [MaxLength(100, ErrorMessage = "The maximum length for the Name of Customer is 100 characters")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Customer Address is Required")]
        [MaxLength(100, ErrorMessage = "The maximum length for the Address of Customer is 100 characters")]
        public string? Address { get; set; }

        [Required(ErrorMessage = "Customer Phone Number is Required")]
        public string? PhoneNumber { get; set; }
    }
}
