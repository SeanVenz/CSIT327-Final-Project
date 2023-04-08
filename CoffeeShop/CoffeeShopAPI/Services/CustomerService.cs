using AutoMapper;
using CoffeeShopAPI.Dtos.Customer;
using CoffeeShopAPI.Models;
using CoffeeShopAPI.Repositories;

namespace CoffeeShopAPI.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CustomerService(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Customer>> GetAllCustomersWithPreference()
        {
            var customerModel = await _customerRepository.GetAllCustomersWithPreference();

            return customerModel.Select(customer => new Customer
            {
                Id = customer.Id,
                Name = customer.Name,
                Address = customer.Address,
                PhoneNumber = customer.PhoneNumber,
                CustomerPrefence = customer.CustomerPrefence
            });
        }

        public async Task<CustomerDto> CreateCustomer(CustomerCreationDto customerDto)
        {
            var customerModel = _mapper.Map<Customer>(customerDto);
            customerModel.Id = await _customerRepository.CreateCustomer(customerModel);
            return _mapper.Map<CustomerDto>(customerModel);
        }

        public async Task<CustomerDto?> GetCustomer(int id)
        {
            var customerModel = await _customerRepository.GetCustomer(id);
            if (customerModel == null) return null;
            return _mapper.Map<CustomerDto>(customerModel);
        }

        public async Task<bool> DeleteCustomer(int id)
        {
            return await _customerRepository.DeleteCustomer(id);
        }

        public async Task<IEnumerable<CustomerDto>> GetAllCustomers()
        {
            var customerModel = await _customerRepository.GetAllCustomers();
            return _mapper.Map<IEnumerable<CustomerDto>>(customerModel);
        }

        public async Task <bool> UpdateCustomer(int id, CustomerCreationDto customerToUpdate)
        {
            var customerModel = _mapper.Map<Customer>(customerToUpdate);
            customerModel.Id = id;
            return await _customerRepository.UpdateCustomer(customerModel);
        }
    }
}
