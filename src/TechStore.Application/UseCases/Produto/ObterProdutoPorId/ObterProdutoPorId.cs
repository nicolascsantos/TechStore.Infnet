using TechStore.Application.UseCases.Produto.Common;
using TechStore.Domain.Repository;

namespace TechStore.Application.UseCases.Produto.ObterProdutoPorId
{
    public class ObterProdutoPorId : IObterProdutoPorId
    {
        private readonly IProdutoRepository _produtoRepository;

        public ObterProdutoPorId(IProdutoRepository produtoRepository)
            => _produtoRepository = produtoRepository;


        public async Task<ProdutoOutput> Handle(ObterProdutoPorIdInput request, CancellationToken cancellationToken)
        {
            var produto = await _produtoRepository.Get(request.Id, cancellationToken);

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
