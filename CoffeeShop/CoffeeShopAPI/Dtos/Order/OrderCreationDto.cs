using System.ComponentModel.DataAnnotations;

namespace CoffeeShopAPI.Dtos.Order
{
    public class OrderCreationDto
    {

        [Required(ErrorMessage = "Order Date is Required")]
        [MaxLength(50, ErrorMessage = "The maximum length for Date is 50 characters")]
        public string? Date { get; set; }

        [Required(ErrorMessage = "Customer Id is Required")]
        public int CustomerID { get; set; }

    }
}
