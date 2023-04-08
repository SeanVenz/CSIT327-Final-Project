using CoffeeShopAPI.Models;

namespace CoffeeShopAPI.Repositories
{
    public interface IBaristaRepository
    {
        /// <summary>
        /// Creates a barista
        /// </summary>
        /// <param name="barista">Barista model</param>
        /// <returns>Id of the new barsita</returns>
        Task<int> CreateBarista(Barista barista);
        
        /// <summary>
        /// Get barista by Id
        /// </summary>
        /// <param name="id">Barista Id</param>
        /// <returns>Barista</returns>
        Task<Barista?> GetBarista(int id);

        /// <summary>
        /// Deletes a barista
        /// </summary>
        /// <param name="id"></param>
        /// <returns>true if successfully deleted, false otherwise</returns>
        Task<bool> DeleteBarista(int id);
        
        /// <summary>
        /// Get all baristas
        /// </summary>
        /// <returns>Baristas</returns>
        Task<IEnumerable<Barista>> GetAllBaristas();
        
        /// <summary>
        /// Updates a barista
        /// </summary>
        /// <param name="barista">New details of barista to be updated</param>
        /// <returns>true if successfully updated, false otherwise</returns>
        Task<bool> UpdateBarista(Barista barista);
    }
}
