using CoffeeShopAPI.Dtos.Barista;
using CoffeeShopAPI.Models;

namespace CoffeeShopAPI.Services
{
    public interface IBaristaService
    {
        Task<BaristaDto> CreateBarista(BaristaCreationDto baristadto);
        Task<BaristaDto?> GetBarista(int id);
        Task<bool> DeleteBarista(int id);
        Task<IEnumerable<BaristaDto>> GetAllBaristas();
        Task UpdateBarista(int id, BaristaCreationDto barista);
    }
}
