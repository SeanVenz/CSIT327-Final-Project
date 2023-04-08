using CoffeeShopAPI.Dtos.Barista;
using CoffeeShopAPI.Dtos.Product;
using CoffeeShopAPI.Dtos.Comment;

namespace CoffeeShopAPI.Dtos.Order
{
    public class OrderGetAllWithCommentsDto
    {
        public int Id { get; set; }
        public string? Date { get; set; }
        public int CustomerID { get; set; }
        public List<BaristaOrderDto> Barista { get; set; } = new List<BaristaOrderDto>();
        public List<ProductOrderDto> Product { get; set; } = new List<ProductOrderDto>();
        public List<CommentDto> Comment{ get; set; } = new List<CommentDto>();
    }
}
