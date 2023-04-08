using CoffeeShopAPI.Dtos.Customer;
using CoffeeShopAPI.Models;

namespace CoffeeShopAPI.Services
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> GetAllCustomersWithPreference();
        Task<IEnumerable<CustomerDto>> GetAllCustomers();
        Task<CustomerDto> CreateCustomer(CustomerCreationDto customer);
        Task<CustomerDto?> GetCustomer(int id);
        Task<bool> DeleteCustomer(int id);
        Task<bool>UpdateCustomer(int id, CustomerCreationDto customer);
    }
}
