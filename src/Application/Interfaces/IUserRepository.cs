using Domain.Entities;

namespace Application.Interfaces;

public interface IUserRepository
{
    Task<ApplicationUser?> GetByEmailAsync(string email);

    Task<ApplicationUser?> GetByIdAsync(int id);

    Task AddAsync(ApplicationUser user);
}