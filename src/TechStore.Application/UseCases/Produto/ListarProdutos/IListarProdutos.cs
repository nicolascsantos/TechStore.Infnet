using MediatR;
using TechStore.Application.UseCases.Produto.Common;

namespace TechStore.Application.UseCases.Produto.ListarProdutos
{
    public interface IListarProdutos : IRequestHandler<ListarProdutosInput, List<ProdutoOutput>>
    {
    }
}
