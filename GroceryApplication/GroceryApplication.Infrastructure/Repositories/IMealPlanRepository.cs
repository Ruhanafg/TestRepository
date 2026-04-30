using GroceryApplication.Domain.Models;

namespace GroceryApplication.Infrastructure.Repositories
{
    public interface IMealPlanRepository
    {
        Task<IEnumerable<MealPlan>> GetMealsByDate(int userId, DateTime date);
        Task AddAsync(MealPlan meal);
    }
}