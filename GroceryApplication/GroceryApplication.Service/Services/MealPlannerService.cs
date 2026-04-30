using GroceryApplication.Domain.Models;
using GroceryApplication.Infrastructure.Repositories;

namespace GroceryApplication.Service
{
    public class MealPlanService
    {
        private readonly IMealPlanRepository _mealPlanRepository;

        public MealPlanService(IMealPlanRepository mealPlanRepository)
        {
            _mealPlanRepository = mealPlanRepository;
        }

        public async Task AddMeal(int userId, MealPlan meal)
        {
            meal.UserId = userId;
            await _mealPlanRepository.AddAsync(meal);
        }

        public async Task<IEnumerable<MealPlan>> GetMealsByDate(int userId, DateTime date)
        {
            return await _mealPlanRepository.GetMealsByDate(userId, date);
        }
    }
}