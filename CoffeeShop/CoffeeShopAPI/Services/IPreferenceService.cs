using CoffeeShopAPI.Dtos.CustomerPreference;

namespace CoffeeShopAPI.Services
{
    public interface IPreferenceService
    {
        /// <summary>
        /// Inserts a preference of the customer
        /// </summary>
        /// <param name="customerId">Id of the customer to be inserted</param>
        /// <param name="customerPreference">Customer's preference</param>
        /// <returns>the id of the preference</returns>
        Task<int> InsertPreference(int customerId, CustomerPreferenceDto customerPreference);

        /// <summary>
        /// Deletes a preference of the customer
        /// </summary>
        /// <param name="customerPreferenceId">Id of the customer preference to be deleted</param>
        /// <returns>true if deleted, false if not</returns>
        Task<bool> DeletePreference(int customerPreferenceId);
    }
}
