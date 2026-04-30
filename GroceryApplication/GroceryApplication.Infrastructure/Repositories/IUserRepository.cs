using GroceryApplication.Domain.Models;

namespace GroceryApplication.Infrastructure.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetByEmailAsync(string email);
        Task AddUserAsync(User user);
    }
}