using CoffeeShopAPI.Dtos.Comment;
using CoffeeShopAPI.Dtos.Barista;
using CoffeeShopAPI.Dtos.Product;

namespace CoffeeShopAPI.Dtos.Order
{
    public class OrderGetAllDto
    {
        public int Id { get; set; }
        public string? Date { get; set; }
        public int CustomerID { get; set; }
        public List<BaristaOrderDto> Barista { get; set; } = new List<BaristaOrderDto>();
        public List<ProductOrderDto> Product { get; set; } = new List<ProductOrderDto>();
    }
}
