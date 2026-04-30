namespace GroceryApplication.WebApi.Models
{
    public class MealPlanRequest
    {
        public DateTime Date { get; set; }
        public string MealType { get; set; }
        public string DishName { get; set; }
    }
}