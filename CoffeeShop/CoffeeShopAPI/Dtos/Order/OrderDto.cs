using CoffeeShopAPI.Dtos.Barista;
using CoffeeShopAPI.Dtos.Product;

namespace CoffeeShopAPI.Dtos.Order
{
    public class OrderDto
    {
        public int Id { get; set; }
        public string? Date { get; set; }
        public int CustomerId { get; set; }
        public List<BaristaDto> Baristas { get; set; } = new List<BaristaDto>();
        public List<ProductDto> Products { get; set; } = new List<ProductDto>();
    }
}
