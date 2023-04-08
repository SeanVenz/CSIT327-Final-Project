namespace CoffeeShopAPI.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public string? PaymentDate { get; set; }
        public int OrdersId { get; set; }
    }
}
