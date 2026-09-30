using TechStore.Application.UseCases.Produto.Common;
using TechStore.Domain.Repository;

namespace TechStore.Application.UseCases.Produto.ListarProdutos
{
    public class ListarProdutos : IListarProdutos
    {
        private readonly IProdutoRepository _produtoRepository;

        public ListarProdutos(IProdutoRepository produtoRepository)
            => _produtoRepository = produtoRepository;

        public async Task<List<ProdutoOutput>> Handle(ListarProdutosInput request, CancellationToken cancellationToken)
        {
            var listaProdutos = await _produtoRepository.ListarTodosProdutos();
            var listaProdutosOutput = new List<ProdutoOutput>();

            listaProdutos.ForEach(produto =>
            {
                listaProdutosOutput.Add(new ProdutoOutput(
                    produto.Id,
                    produto.NomeProduto,
                    produto.Descricao,
                    produto.QuantidadeEmEstoque,
                    produto.ValorUnitario,
                    produto.CriadoEm
                ));
            });

            return listaProdutosOutput;
        }
    }
}
