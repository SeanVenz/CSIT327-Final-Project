namespace CoffeeShopAPI.Dtos.Comment
{
    public class CommentDto
    {
        public int Id { get; set; }
        public string? Comments { get; set; }
        public int OrdersId { get; set; }
    }
}
