using MediatR;
using TechStore.Application.UseCases.Produto.Common;

namespace TechStore.Application.UseCases.Produto.ListarProdutos
{
    public class ListarProdutosInput : IRequest<List<ProdutoOutput>>
    {
    }
}
