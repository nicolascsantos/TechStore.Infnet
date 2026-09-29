using MediatR;
using TechStore.Application.Interfaces;
using TechStore.Domain.Repository;

namespace TechStore.Application.UseCases.Produto.DeletarProduto
{
    public class DeletarProduto : IDeletarProduto
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeletarProduto(IProdutoRepository produtoRepository, IUnitOfWork unitOfWork)
        {
            _produtoRepository = produtoRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeletarProdutoInput request, CancellationToken cancellationToken)
        {
            var produtoASerDeletado = await _produtoRepository.Get(request.Id, cancellationToken);

            await _produtoRepository.Delete(produtoASerDeletado, cancellationToken);
            await _unitOfWork.Commit(cancellationToken);

            return await Task.FromResult(Unit.Value);
        }
    }
}
