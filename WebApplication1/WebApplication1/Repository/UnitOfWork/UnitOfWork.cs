using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace WebApplication1.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext context;
        private readonly ILogger<UnitOfWork> logger;

        public UnitOfWork(DbContext context, ILogger<UnitOfWork> logger)
        {
            this.context = context;
            this.logger = logger;
        }

        public async Task CompleteAsync()
        {
            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                logger.LogError($"Error saving the context changes : {ex}. Inner exception details: {ex.InnerException}");
            }
            catch (Exception ex)
            {
                logger.LogError($"Error saving the context changes : {ex}. Inner exception details: {ex.InnerException}");
            }
        }
    }
}
