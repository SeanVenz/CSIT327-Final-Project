using AutoMapper;
using CoffeeShopAPI.Dtos.Customer;
using CoffeeShopAPI.Dtos.CustomerPreference;
using CoffeeShopAPI.Models;
using CoffeeShopAPI.Repositories;

namespace CoffeeShopAPI.Services
{
    public class CustomerPreferenceService : ICustomerPreferenceService
    {
        private readonly ICustomerPreferenceRepository _customerPreferenceRepository;
        private readonly IMapper _mapper;

        public CustomerPreferenceService(ICustomerPreferenceRepository customerPreferenceService, IMapper mapper)
        {
            _customerPreferenceRepository = customerPreferenceService;
            _mapper = mapper;
        }

        public async Task<bool> DeleteCustomerPreference(int id)
        {
            return await _customerPreferenceRepository.DeleteCustomerPreference(id);
        }

        public async Task<IEnumerable<CustomerPreferenceWithAllDto>> GetAllCustomerPreferences()
        {
            var customerPreferences = await _customerPreferenceRepository.GetAllCustomerPreferences();
            return _mapper.Map<IEnumerable<CustomerPreferenceWithAllDto>>(customerPreferences);
        }

        public async Task<CustomerPreferenceWithAllDto?> GetCustomerPreference(int id)
        {
            var customerPreferenceModel = await _customerPreferenceRepository.GetCustomerPreference(id);
            if (customerPreferenceModel == null) return null;

            return _mapper.Map<CustomerPreferenceWithAllDto>(customerPreferenceModel);
        }

        public async Task<bool> UpdatePreference(int customerPreferenceId, CustomerPreferenceCreationDto customerPreferenceToUpdate)
        {
            var preferenceModel = _mapper.Map<CustomerPreference>(customerPreferenceToUpdate);
            preferenceModel.Id = customerPreferenceId;
            return await _customerPreferenceRepository.UpdatePreference(preferenceModel);

        }
    }
}
