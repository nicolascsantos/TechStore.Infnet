using TechStore.Domain.Entities;
using TechStore.Domain.SeedWork;

namespace TechStore.Domain.Repository
{
    public interface IProdutoRepository : IGenericRepository<Produto>
    {
        public Task<List<Produto>> ListarTodosProdutos();
    }
}
