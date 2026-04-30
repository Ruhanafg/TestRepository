using GroceryApplication.Domain.Models;
using GroceryApplication.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GroceryApplication.Infrastructure.Repositories
{
    public class GroceryRepository : IGroceryRepository
    {
        private readonly AppDbContext _context;

        public GroceryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GroceryList>> GetAllAsync()
        {
            return await _context.GroceryLists.ToListAsync();
        }

        public async Task AddAsync(GroceryList item)
        {
            await _context.GroceryLists.AddAsync(item);
            await _context.SaveChangesAsync();
        }
    }
}