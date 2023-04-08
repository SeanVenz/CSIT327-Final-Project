using CoffeeShopAPI.Dtos.Product;
using CoffeeShopAPI.Models;
using CoffeeShopAPI.Repositories;

namespace CoffeeShopAPI.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepositoryservice;
        public ProductService(IProductRepository product)
        {
            _productRepositoryservice = product;
        }

        public async Task<ProductDto> CreateProduct(ProductCreationDto productdto)
        {
            var productModel = new Product
            {
                Category = productdto.Category,
                Name = productdto.Name,
                Description = productdto.Description,
                Price = productdto.Price,
            };
            productModel.Id = await _productRepositoryservice.CreateProduct(productModel);

            return new ProductDto
            {
                Id = productModel.Id,
                Category = productModel.Category,
                Name= productModel.Name,
                Description= productModel.Description,
                Price= productModel.Price
            };
        }

        public async Task<bool> DeleteProduct(int id)
        {
            return await _productRepositoryservice.DeleteProduct(id);
        }

        public async Task<IEnumerable<ProductDto>> GetAllProducts()
        {
            var productModels = await _productRepositoryservice.GetAllProducts();
            return productModels.Select(product => new ProductDto
            {
                Id = product.Id,
                Category = product.Category,
                Name= product.Name,
                Description= product.Description,
                Price= product.Price
            });
        }

        public async Task<ProductDto?> GetProduct(int id)
        {
            var productModel = await _productRepositoryservice.GetProduct(id);
            if (productModel == null) { return null; }
            return new ProductDto
            {
                Id = productModel.Id,
                Category = productModel.Category,
                Name = productModel.Name,
                Description = productModel.Description,
                Price = productModel.Price,
            };
        }

        public async Task UpdateProduct(int id, ProductCreationDto productupdate)
        {
            var productModel = new Product
            {
                Id = id,
                Category = productupdate.Category,
                Name = productupdate.Name,
                Description = productupdate.Description,
                Price = productupdate.Price
            };
            var product = await _productRepositoryservice.UpdateProduct(productModel);
        }

    }
}
