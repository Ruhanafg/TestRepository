using TaskApp.DAL;
using TaskApp.Model;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace TaskApp.Service
{
    public class AuthService
    {
        private readonly TaskApplicationDbContext _context;

        public AuthService(TaskApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<string> Register(RegisterDto dto)
        {
            var exists = await _context.Users
                .AnyAsync(x => x.Name == dto.Name);

            if (exists)
                return "User already exists";

            var user = new UserModel
            {
                Name = dto.Name,
                Email = dto.Email,
                PasswordHash = HashPassword(dto.Password),
                Role = "User",
                Gender = "NotSpecified"
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return "Registered Successfully";
        }

        public async Task<UserModel?> Login(LoginDto dto)
        {
            var hash = HashPassword(dto.Password);

            return await _context.Users.FirstOrDefaultAsync(x =>
                x.Name == dto.Name &&
                x.PasswordHash == hash);
        }

        private string HashPassword(string password)
        {
            using var sha = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(password);
            return Convert.ToBase64String(sha.ComputeHash(bytes));
        }
    }
}