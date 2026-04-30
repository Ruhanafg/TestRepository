using GroceryApplication.Domain.Models;

namespace GroceryApplication.Infrastructure.Repositories
{
    public interface IGroceryRepository
    {
        Task<IEnumerable<GroceryList>> GetAllAsync();
        Task AddAsync(GroceryList item);
    }
}