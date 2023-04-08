namespace CoffeeShopAPI.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string? Comments { get; set; }
        public int OrdersId { get; set; }
    }
}
