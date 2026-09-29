using TechStore.Domain.Entities;
using TechStore.Domain.Repository;

namespace TechStore.Data.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        public Task Delete(Produto aggregate, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Produto> Get(Guid id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task Insert(Produto aggregate, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task Update(Produto aggregate, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
