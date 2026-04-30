namespace GroceryApplication.WebApi.Models
{
    public class RegisterRequest
    {
        public string Username { get; set; }   // 👤 display name
        public string Email { get; set; }      // 📧 login email
        public string Password { get; set; }   // 🔐 plain password (will be hashed)
    }
}