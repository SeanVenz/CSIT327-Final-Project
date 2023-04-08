using AutoMapper;
using CoffeeShopAPI.Dtos.Customer;
using CoffeeShopAPI.Dtos.CustomerPreference;
using CoffeeShopAPI.Models;
using CoffeeShopAPI.Repositories;

namespace CoffeeShopAPI.Services
{
    public class PreferenceService : IPreferenceService
    {
        private readonly ICustomerPreferenceRepository _preferenceRepository;
        private readonly IMapper _mapper;
        public PreferenceService(ICustomerPreferenceRepository preferenceRepository, IMapper mapper)
        {
            _preferenceRepository = preferenceRepository;
            _mapper = mapper;
        }

        public async Task<bool> DeletePreference(int customerPreferenceId)
        {
            return await _preferenceRepository.DeleteCustomerPreference(customerPreferenceId);
        }

        public async Task<int> InsertPreference(int customerId, CustomerPreferenceDto customerPreference)
        {
            var preferenceModel = _mapper.Map<CustomerPreference>(customerPreference);
            preferenceModel.CustomerId = customerId;
            return await _preferenceRepository.CreateCustomerPreference(preferenceModel);
        }
    }
}
