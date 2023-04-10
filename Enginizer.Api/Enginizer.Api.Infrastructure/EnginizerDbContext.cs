using Enginizer.Api.Domain.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Enginizer.Api.Infrastructure
{
    public class EnginizerDbContext : DbContext
    {
        public EnginizerDbContext(DbContextOptions<EnginizerDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
    }
}
