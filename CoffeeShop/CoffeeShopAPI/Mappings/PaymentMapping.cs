using AutoMapper;
using CoffeeShopAPI.Dtos.Payment;
using CoffeeShopAPI.Models;

namespace CoffeeShopAPI.Mappings
{
    public class PaymentMapping : Profile
    {
        public PaymentMapping() 
        {
            CreateMap<Payment, PaymentDto>();
            CreateMap<PaymentCreationDto, Payment>();
        }
    }
}
