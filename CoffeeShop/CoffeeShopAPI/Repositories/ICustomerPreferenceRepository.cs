using CoffeeShopAPI.Models;

namespace CoffeeShopAPI.Repositories
{
    public interface ICustomerPreferenceRepository
    {
        /// <summary>
        /// Gets all the preferences of customers
        /// </summary>
        /// <returns>Preferences of Customers</returns>
        Task<IEnumerable<CustomerPreference>> GetAllCustomerPreferences();

        /// <summary>
        /// Creates a new Customer Preference
        /// </summary>
        /// <param name="customerPreference">Customer Preference Model</param>
        /// <returns>Id of the newly created preference</returns>
        Task<int> CreateCustomerPreference(CustomerPreference customerPreference);

        /// <summary>
        /// Gets a single customer preference
        /// </summary>
        /// <param name="id">Id of the Preference</param>
        /// <returns>the Customer Preference</returns>
        Task<CustomerPreference> GetCustomerPreference(int id);

        /// <summary>
        /// Deletes a customer Preference
        /// </summary>
        /// <param name="id">Id of the customer preference</param>
        /// <returns>true if deleted, false if not</returns>
        Task<bool> DeleteCustomerPreference(int id);

        /// <summary>
        /// Updates a Preference of a Custoemr
        /// </summary>
        /// <param name="customerPreference">Customer Preference Model</param>
        /// <returns>true if updated, false if not</returns>
        Task<bool> UpdatePreference(CustomerPreference customerPreference);
    }
}
