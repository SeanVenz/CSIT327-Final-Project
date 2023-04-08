using AutoMapper;
using CoffeeShopAPI.Models;
using CoffeeShopAPI.Dtos.Customer;
namespace CoffeeShopAPI.Mappings
{ 

    public class CustomerMapping : Profile
    {
        public CustomerMapping()
        {
            CreateMap<Customer, CustomerDto>();
            CreateMap<CustomerCreationDto, Customer>();
            CreateMap<Customer, CustomerGetAllDto>();
            CreateMap<CustomerGetAllDto, Customer>();
        }
    }
}
