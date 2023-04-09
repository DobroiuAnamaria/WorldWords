using WebApplication1.Model;

namespace WebApplication1.Repository
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
