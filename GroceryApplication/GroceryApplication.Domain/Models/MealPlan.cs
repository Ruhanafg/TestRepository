namespace GroceryApplication.Domain.Models
{
    public class MealPlan
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public string MealType { get; set; } // Breakfast/Lunch/Dinner
        public string DishName { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
