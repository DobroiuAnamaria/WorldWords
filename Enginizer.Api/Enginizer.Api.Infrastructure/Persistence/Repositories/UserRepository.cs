using Enginizer.Api.Domain.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Enginizer.Api.Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly EnginizerDbContext _enginizerDbContext;

        public UserRepository(EnginizerDbContext enginizerDbContext)
        {
            _enginizerDbContext = enginizerDbContext;
        }



        public async Task<User> FindByIdAsync(int id)
        {
            var user = await _enginizerDbContext.Users.FindAsync(id);
            if (user == null) { throw new Exception(); } // TODO: implement

            return user;

        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _enginizerDbContext.Users.ToListAsync();
        }

        public async Task<User> AddAsync(User user)
        {
            _enginizerDbContext.Users.Add(user);
            await _enginizerDbContext.SaveChangesAsync();

            return user;
        }

        public async Task<User> UpdateAsync(User user)
        {
            _enginizerDbContext.Users.Update(user);
            await _enginizerDbContext.SaveChangesAsync();

            return user;
        }

        public async Task<int> DeleteAsync(int id)
        {
            var user = await _enginizerDbContext.Users.FindAsync(id);
            if (user == null) { throw new Exception(); } // TODO: handle null check properly

            _enginizerDbContext.Users.Remove(user);
            await _enginizerDbContext.SaveChangesAsync();

            return id;
        }
    }
}
