using CoffeeShopAPI.Models;

namespace CoffeeShopAPI.Repositories
{
    public interface ICustomerRepository
    {
        /// <summary>
        /// Gets all Customers with Preferences
        /// </summary>
        /// <returns>Customers with Preferences</returns>
        Task<IEnumerable<Customer>> GetAllCustomersWithPreference();

        /// <summary>
        /// Gets All Customers only
        /// </summary>
        /// <returns>Customers only</returns>
        Task<IEnumerable<Customer>> GetAllCustomers();

        /// <summary>
        /// Creates a new Customer
        /// </summary>
        /// <param name="customer">Customer model</param>
        /// <returns>Id of the newly created Customer</returns>
        Task<int> CreateCustomer(Customer customer);

        /// <summary>
        /// Gets a single Customer 
        /// </summary>
        /// <param name="id">Id of the customer</param>
        /// <returns>the Customer</returns>
        Task<Customer> GetCustomer(int id);

        /// <summary>
        /// Deletes a customer
        /// </summary>
        /// <param name="id">Id of the Customer to be deleted</param>
        /// <returns>true if deleted, false if not</returns>
        Task<bool> DeleteCustomer(int id);

        /// <summary>
        /// Updates a customer
        /// </summary>
        /// <param name="customer">New details of customer to be updated</param>
        /// <returns>true if updated, false if not</returns>
        Task<bool> UpdateCustomer(Customer customer);
    }
}
