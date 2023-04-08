using CoffeeShopAPI.Dtos.Barista;
using CoffeeShopAPI.Dtos.Product;

namespace CoffeeShopAPI.Models
{
    public class Order
    {
        /// <summary>
        /// Properties for Orders
        /// </summary>
        public int Id { get; set; }
        public string? Date { get; set; }
        public int CustomerId { get; set; }
        public List<BaristaDto> Baristas { get; set; } = new List<BaristaDto>();
        public List<ProductDto> Products { get; set; } = new List<ProductDto>();
        public List<Comment> Comments { get; set; } = new List<Comment>();

    }
}
