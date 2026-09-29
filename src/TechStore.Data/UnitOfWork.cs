using TechStore.Application.Interfaces;

namespace TechStore.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TechStoreDbContext _context;

        public UnitOfWork(TechStoreDbContext context)
            => _context = context;

        public async Task Commit(CancellationToken cancellationToken)
            => await _context.SaveChangesAsync(cancellationToken);

        public async Task Rollback(CancellationToken cancellationToken)
            => await Task.CompletedTask;
    }
}
