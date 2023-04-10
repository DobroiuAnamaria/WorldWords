using Enginizer.Api.Domain.Domain.Entities;

namespace Enginizer.Api.Infrastructure.Persistence.Repositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllAsync();
        Task<User> FindByIdAsync(int id);
        Task<User> AddAsync(User user);
        Task<User> UpdateAsync(User user);
        Task<int> DeleteAsync(int id);

    }
}
