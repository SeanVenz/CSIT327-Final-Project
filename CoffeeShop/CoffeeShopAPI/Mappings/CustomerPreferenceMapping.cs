using AutoMapper;
using CoffeeShopAPI.Dtos.CustomerPreference;
using CoffeeShopAPI.Models;
namespace CoffeeShopAPI.Mappings  
{
    public class CustomerPreferenceMapping : Profile
    {
        public CustomerPreferenceMapping()
        {
            CreateMap<CustomerPreference, CustomerPreferenceWithAllDto>();
            CreateMap<CustomerPreferenceWithAllDto, CustomerPreference>();
            CreateMap<CustomerPreference, CustomerPreferenceCreationDto>();
            CreateMap<CustomerPreferenceCreationDto, CustomerPreference>();
            CreateMap<CustomerPreferenceDto, CustomerPreference>();
            CreateMap<CustomerPreference, CustomerPreferenceDto>();
        }
    }
}
