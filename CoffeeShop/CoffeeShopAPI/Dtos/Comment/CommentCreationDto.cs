using System.ComponentModel.DataAnnotations;

namespace CoffeeShopAPI.Dtos.Comment
{
    public class CommentCreationDto
    {
        [Required(ErrorMessage = "Comment Comments is Required")]
        [MaxLength(200, ErrorMessage = "The maximum length for the Comments is 200 characters")]
        public string? Comments { get; set; }
        public int OrdersId { get; set; }
    }
}
