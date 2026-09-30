using TechStore.Application.Interfaces;
using TechStore.Application.UseCases.Produto.Common;
using TechStore.Domain.Repository;
using Entidade = TechStore.Domain.Entities;

namespace TechStore.Application.UseCases.Produto.CriarProduto
{
    public class CriarProduto : ICriarProduto
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CriarProduto(IProdutoRepository produtoRepository, IUnitOfWork unitOfWork)
        {
            _produtoRepository = produtoRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ProdutoOutput> Handle(CriarProdutoInput request, CancellationToken cancellationToken)
        {
            var produto = new Entidade.Produto(
                request.NomeProduto,
                request.Descricao,
                request.QuantidadeEmEstoque,
                request.ValorUnitario
            );

            await _produtoRepository.Insert(produto, cancellationToken);
            await _unitOfWork.Commit(cancellationToken);

            return new ProdutoOutput(
                produto.Id,
                produto.NomeProduto,
                produto.Descricao,
                produto.QuantidadeEmEstoque,
                produto.ValorUnitario,
                produto.CriadoEm
            );
        }
    }
}
