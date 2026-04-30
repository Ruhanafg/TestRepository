using GroceryApplication.Domain.Models;
using GroceryApplication.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using GroceryApplication.WebApi.Models;


namespace GroceryApplication.WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class MealPlanController : ControllerBase
    {
        private readonly MealPlanService _mealPlanService;

        public MealPlanController(MealPlanService mealPlanService)
        {
            _mealPlanService = mealPlanService;
        }

        private int GetUserId()
        {
            return int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
        }

        [HttpPost]
        public async Task<IActionResult> AddMeal(MealPlanRequest request)
        {
            var userId = GetUserId();

            var meal = new MealPlan
            {
                Date = request.Date,
                MealType = request.MealType,
                DishName = request.DishName
            };

            await _mealPlanService.AddMeal(userId, meal);

            return Ok("Meal added");
        }

        [HttpGet]
        public async Task<IActionResult> GetMealsByDate(DateTime date)
        {
            var userId = GetUserId();
            var meals = await _mealPlanService.GetMealsByDate(userId, date);
            return Ok(meals);
        }
    }
}