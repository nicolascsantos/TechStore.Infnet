namespace TechStore.Domain.SeedWork
{
    public interface IGenericRepository<TEntidade> : IRepository where TEntidade : Entidade
    {
        public Task Insert(TEntidade aggregate, CancellationToken cancellationToken);

        public Task<TEntidade> Get(Guid id, CancellationToken cancellationToken);

        public Task Delete(TEntidade aggregate, CancellationToken cancellationToken);

        public Task Update(TEntidade aggregate, CancellationToken cancellationToken);
    }
}
