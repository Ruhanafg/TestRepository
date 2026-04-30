using GroceryApplication.Domain.Models;
using GroceryApplication.Infrastructure.Repositories;

namespace GroceryApplication.Service
{
    public class GroceryService
    {
        private readonly IGroceryRepository _groceryRepository;

        public GroceryService(IGroceryRepository groceryRepository)
        {
            _groceryRepository = groceryRepository;
        }

        public async Task<IEnumerable<GroceryList>> GetAllItems()
        {
            return await _groceryRepository.GetAllAsync();
        }

        public async Task AddItem(GroceryList item)
        {
            await _groceryRepository.AddAsync(item);
        }
    }
}