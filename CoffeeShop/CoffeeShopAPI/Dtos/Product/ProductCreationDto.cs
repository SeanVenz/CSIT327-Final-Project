using System.ComponentModel.DataAnnotations;

namespace CoffeeShopAPI.Dtos.Product
{
    public class ProductCreationDto
    {
        [Required(ErrorMessage = "The product category is required.")]
        public string? Category { get; set; }

        [Required(ErrorMessage = "The product name is required.")]
        public string? Name { get; set; }

        [MaxLength(100, ErrorMessage ="Maximum length for the product description is 150")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "The product price is required.")]
        [Range(100, double.MaxValue,ErrorMessage ="Price must be atleast 100.")]
        public double Price { get; set; }
    }
}
