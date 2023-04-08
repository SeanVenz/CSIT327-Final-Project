using AutoMapper;
using CoffeeShopAPI.Dtos.Barista;
using CoffeeShopAPI.Models;

namespace CoffeeShopAPI.Mappings
{
    public class BaristaMapping : Profile
    {
        public BaristaMapping()
        {
            CreateMap<Barista, BaristaDto>();
            CreateMap<BaristaCreationDto, Barista>();
        }
    }
}
