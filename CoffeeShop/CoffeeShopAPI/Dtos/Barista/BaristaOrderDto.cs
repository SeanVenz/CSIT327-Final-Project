using CoffeeShopAPI.Dtos.Order;

namespace CoffeeShopAPI.Dtos.Barista
{
    public class BaristaOrderDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<OrderDto>? Orders { get; set; } = new List<OrderDto>();
    }
}
