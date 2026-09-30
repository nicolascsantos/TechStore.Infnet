using TechStore.Application.Interfaces;
using TechStore.Application.UseCases.Produto.Common;
using TechStore.Domain.Repository;

namespace TechStore.Application.UseCases.Produto.AtualizarProduto
{
    public class AtualizarProduto : IAtualizarProduto
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AtualizarProduto(IProdutoRepository produtoRepository, IUnitOfWork unitOfWork)
        {
            _produtoRepository = produtoRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ProdutoOutput> Handle(AtualizarProdutoInput request, CancellationToken cancellationToken)
        {
            var produto = await _produtoRepository.Get(request.Id, cancellationToken);
            produto.Atualizar(
                request.NomeProduto,
                request.Descricao,
                request.QuantidadeEmEstoque,
                request.ValorUnitario
            );

            await _produtoRepository.Update(produto, cancellationToken);
            await _unitOfWork.Commit(cancellationToken);

            return new ProdutoOutput(
                produto.Id,
                produto.NomeProduto, 
                produto.Descricao,
                produto.QuantidadeEmEstoque,
                produto.QuantidadeEmEstoque,
                produto.CriadoEm
            );
        }
    }
}
