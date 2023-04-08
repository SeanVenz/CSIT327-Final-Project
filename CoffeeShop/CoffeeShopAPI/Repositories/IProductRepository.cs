using CoffeeShopAPI.Models;

namespace CoffeeShopAPI.Repositories
{
    public interface IProductRepository
    {
        /// <summary>
        /// Get all products
        /// </summary>
        /// <returns> Products </returns>
        Task<IEnumerable<Product>> GetAllProducts();

        /// <summary>
        /// Creates products
        /// </summary>
        /// <param name="product"> product model </param>
        /// <returns> id of new product</returns>
        Task<int> CreateProduct(Product product);

        /// <summary>
        /// Get product by id
        /// </summary>
        /// <param name="id">product id</param>
        /// <returns>product</returns>
        Task<Product?> GetProduct(int id);

        /// <summary>
        /// Deletes a product
        /// </summary>
        /// <param name="id">product id</param>
        /// <returns>true if successfully updated, false otherwise</returns>
        Task<bool> DeleteProduct(int id);

        /// <summary>
        /// /Updates a product
        /// </summary>
        /// <param name="product">new product details</param>
        /// <returns>true if successfully updated, false otherwise</returns>
        Task<bool> UpdateProduct(Product product);
    }
}
