using CoffeeShopAPI.Dtos.Barista;
using CoffeeShopAPI.Dtos.Product;
using CoffeeShopAPI.Dtos.Payment;
using CoffeeShopAPI.Dtos.Comment;

namespace CoffeeShopAPI.Dtos.Order
{
    public class OrderWithAllDto
    {
        public int Id { get; set; }
        public string? Date { get; set; }
        public int CustomerId { get; set; }
        public List<BaristaDto> Baristas { get; set; } = new List<BaristaDto>();
        public List<ProductDto> Products { get; set; } = new List<ProductDto>();
        public int? PaymentId{ get; set; }
        public List<CommentDto> Comments { get; set; } = new List<CommentDto>();
    }
}
