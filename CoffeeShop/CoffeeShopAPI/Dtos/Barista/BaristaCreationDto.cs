using System.ComponentModel.DataAnnotations;

namespace CoffeeShopAPI.Dtos.Barista
{
    public class BaristaCreationDto
    {
        [Required(ErrorMessage ="The barista name is required.")]
        public string? Name { get; set; }
    }
}
