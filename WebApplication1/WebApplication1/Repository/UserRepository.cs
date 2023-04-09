using WebApplication1.Model;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _dbContext;

        public UserRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> FindByIdAsync(int id)
        {
            var user = await _dbContext.Users.FindAsync(id);
            if (user == null) { throw new Exception(); } // TODO: implement

            return user;

        }
        
        public async Task<List<User>> GetAllAsync()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<User> AddAsync(User user)
        {
            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();

            return user;
        }

        public async Task<User> UpdateAsync(User user)
        {
            _dbContext.Users.Update(user);
            await _dbContext.SaveChangesAsync();

            return user;
        }

        public async Task<int> DeleteAsync(int id)
        {
            var user = await _dbContext.Users.FindAsync(id);
            if (user == null) { throw new Exception(); } // TODO: handle null check properly

            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();

            return id;
        }
    }
}
