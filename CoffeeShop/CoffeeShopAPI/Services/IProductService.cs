using CoffeeShopAPI.Dtos.Product;
using CoffeeShopAPI.Models;

namespace CoffeeShopAPI.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllProducts();
        Task<ProductDto> CreateProduct(ProductCreationDto productdto);
        Task<ProductDto?> GetProduct(int id);
        Task<bool> DeleteProduct(int id);
        Task UpdateProduct(int id, ProductCreationDto product);
    }
}
