using GroceryApplication.Domain.Models;
using GroceryApplication.Infrastructure.Repositories;
using System.Security.Cryptography;
using System.Text;

namespace GroceryApplication.Service
{
    public class AuthService
    {
        private readonly IUserRepository _userRepository;

        public AuthService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Register(string username, string email, string password)
        {
            var existingUser = await _userRepository.GetByEmailAsync(email);
            if (existingUser != null)
                return false;

            var user = new User
            {
                Username = username,
                Email = email,
                PasswordHash = HashPassword(password)
            };

            await _userRepository.AddUserAsync(user);
            return true;
        }

        public async Task<User?> Login(string email, string password)
        {
            var user = await _userRepository.GetByEmailAsync(email);

            if (user == null || user.PasswordHash != HashPassword(password))
                return null;

            return user;
        }

        private string HashPassword(string password)
        {
            using var sha = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(password);
            return Convert.ToBase64String(sha.ComputeHash(bytes));
        }
    }
}