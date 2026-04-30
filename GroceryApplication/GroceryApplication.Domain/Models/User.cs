namespace GroceryApplication.Domain.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; } 
        public ICollection<MealPlan> MealPlans { get; set; }= new List<MealPlan>();
    }
}