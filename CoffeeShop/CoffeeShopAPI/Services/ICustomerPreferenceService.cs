using CoffeeShopAPI.Dtos.CustomerPreference;
using CoffeeShopAPI.Models;

namespace CoffeeShopAPI.Services
{
    public interface ICustomerPreferenceService
    {
        /// <summary>
        /// Gets all customer preferences
        /// </summary>
        /// <returns>All the customer preferences</returns>
        Task<IEnumerable<CustomerPreferenceWithAllDto>> GetAllCustomerPreferences();
        
        /// <summary>
        /// Gets a single Customer Preference
        /// </summary>
        /// <param name="id">id of the preference</param>
        /// <returns>CustomerPreferenceDto</returns>
        Task<CustomerPreferenceWithAllDto?> GetCustomerPreference(int id);
        
        /// <summary>
        /// Updates a customer preference
        /// </summary>
        /// <param name="customerPreferenceId">id of the preference</param>
        /// <param name="customerPreferenceToUpdate">input of the preference to update</param>
        /// <returns>updated preference</returns>
        Task <bool> UpdatePreference(int customerPreferenceId, CustomerPreferenceCreationDto customerPreferenceToUpdate);
        
        /// <summary>
        /// Deletes a customer preference
        /// </summary>
        /// <param name="id">Id of the customer preference</param>
        /// <returns>true if updated, false if not</returns>
        Task<bool> DeleteCustomerPreference(int id);
    }
}
