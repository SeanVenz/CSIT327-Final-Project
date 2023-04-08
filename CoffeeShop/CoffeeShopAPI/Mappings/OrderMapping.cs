using AutoMapper;
using CoffeeShopAPI.Dtos.Customer;
using CoffeeShopAPI.Dtos.Order;
using CoffeeShopAPI.Models;

namespace CoffeeShopAPI.Mappings
{
    public class OrderMapping : Profile
    {
        public OrderMapping()
        {
            CreateMap<Order, OrderDto>();
            CreateMap<OrderCreationDto, Order>();
            CreateMap<OrderWithAllDto, Order>();
            CreateMap<Order, OrderWithAllDto>();
            CreateMap<Order, OrderGetAllDto>();
            CreateMap<OrderGetAllDto, Order>();
            CreateMap<Order, OrderGetAllWithCommentsDto>();
            CreateMap<OrderGetAllWithCommentsDto, Order>();
            CreateMap<Order, OrderCreationDto>();
            CreateMap<OrderCreationDto, Order>();
            CreateMap<OrderDto, Order>();
            CreateMap<Order, OrderDto>();
        }
    }
}
