using CoffeeShopAPI.Dtos.Barista;
using CoffeeShopAPI.Models;
using CoffeeShopAPI.Repositories;

namespace CoffeeShopAPI.Services
{
    public class BaristaService : IBaristaService
    {
        private readonly IBaristaRepository _baristaRepository;
        public BaristaService(IBaristaRepository baristaRepository)
        {
            _baristaRepository = baristaRepository;
        }

        public async Task<BaristaDto> CreateBarista(BaristaCreationDto baristaToCreate)
        {
            var baristaModel = new Barista
            {
                Name = baristaToCreate.Name
            };
            baristaModel.Id = await _baristaRepository.CreateBarista(baristaModel);

            return new BaristaDto
            {
                Id = baristaModel.Id,
                Name = baristaModel.Name
            };
        }

        public async Task<bool> DeleteBarista(int id)
        {
            return await _baristaRepository.DeleteBarista(id);
        }

        public async Task<IEnumerable<BaristaDto>> GetAllBaristas()
        {
            var baristamodels = await _baristaRepository.GetAllBaristas();
            return baristamodels.Select(barista => new BaristaDto
            {
                Id= barista.Id,
                Name= barista.Name
            });
        }

        public async Task<BaristaDto?> GetBarista(int id)
        {
            var baristaModel = await _baristaRepository.GetBarista(id);

            if (baristaModel == null) { return null; }

            return new BaristaDto
            {
                Id = baristaModel.Id,
                Name = baristaModel.Name
            };
        }

        public async Task UpdateBarista(int id, BaristaCreationDto baristaupdate)
        {
            var baristaModel = new Barista
            {
                Id = id,
                Name = baristaupdate.Name,
            };
            var barista =  await _baristaRepository.UpdateBarista(baristaModel);
        }
    }
}
