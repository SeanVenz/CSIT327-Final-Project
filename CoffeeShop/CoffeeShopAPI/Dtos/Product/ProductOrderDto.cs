using CoffeeShopAPI.Dtos.Order;

namespace CoffeeShopAPI.Dtos.Product
{
    public class ProductOrderDto
    {
        public int Id { get; set; }
        public string? Category { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }
        public List<OrderDto>? Orders{ get; set; } = new List<OrderDto>();
    }
}
