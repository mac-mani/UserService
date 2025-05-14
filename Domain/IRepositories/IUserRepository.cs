using Domain.Entities;

namespace Domain.IRepositories;

public interface IUserRepository
{
    Task<ApplicationUser?> InsertUserAsync(ApplicationUser user);
    Task<ApplicationUser?> UpdateUserAsync(ApplicationUser user, string userId);
    Task<ApplicationUser?> GetUserByEmailAsync(string email);
}