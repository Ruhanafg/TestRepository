using GroceryApplication.Domain.Models;
using GroceryApplication.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GroceryApplication.Infrastructure.Repositories
{
    public class MealPlanRepository : IMealPlanRepository
    {
        private readonly AppDbContext _context;

        public MealPlanRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(MealPlan meal)
        {
            await _context.MealPlans.AddAsync(meal);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<MealPlan>> GetMealsByDate(int userId, DateTime date)
        {
            return await _context.MealPlans
                .Where(m => m.UserId == userId && m.Date.Date == date.Date)
                .ToListAsync();
        }
    }
}