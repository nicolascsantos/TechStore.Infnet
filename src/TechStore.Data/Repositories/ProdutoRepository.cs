using TechStore.Application.Exceptions;
using Microsoft.EntityFrameworkCore;
using TechStore.Domain.Entities;
using TechStore.Domain.Repository;

namespace TechStore.Data.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly TechStoreDbContext _context;
        private DbSet<Produto> _produtos => _context.Set<Produto>();

        public ProdutoRepository(TechStoreDbContext context)
            => _context = context;

        public async Task Delete(Produto produto, CancellationToken cancellationToken)
            => await Task.FromResult(_context.Remove(produto));

        public async Task<Produto> Get(Guid id, CancellationToken cancellationToken)
            => await _produtos.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id) ?? throw new NotFoundException($"Produto '{id}' não encontrado");

        public async Task Insert(Produto produto, CancellationToken cancellationToken)
            => await _context.AddAsync(produto, cancellationToken);

        public async Task Update(Produto produto, CancellationToken cancellationToken)
            => await Task.FromResult(_context.Produtos.Update(produto));

        public Task<List<Produto>> ListarTodosProdutos()
            => _context.Produtos.AsNoTracking().ToListAsync();
    }
}
