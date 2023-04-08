using System.ComponentModel.DataAnnotations;

namespace CoffeeShopAPI.Dtos.Payment
{
    public class PaymentCreationDto
    {
        [Required(ErrorMessage = "Payment Amount is Required")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "Payment PaymentDate is Required")]
        [MaxLength(50, ErrorMessage = "The maximum length for the PaymentDate is 50 characters")]
        public string? PaymentDate { get; set; }
        public int OrdersId { get; set; }
    }
}
