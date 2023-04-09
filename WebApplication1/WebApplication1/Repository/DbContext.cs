using WebApplication1.Model;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Repository
{
    public class DbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbContext(DbContextOptions<DbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
    }
}
