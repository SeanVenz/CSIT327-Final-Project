using AutoMapper;
using CoffeeShopAPI.Dtos.Product;
using CoffeeShopAPI.Models;

namespace CoffeeShopAPI.Mappings
{
    public class ProductMapping : Profile
    {
        public ProductMapping()
        {
            CreateMap<Product,ProductDto>();
            CreateMap<ProductCreationDto,Product>();
        }
    }
}
