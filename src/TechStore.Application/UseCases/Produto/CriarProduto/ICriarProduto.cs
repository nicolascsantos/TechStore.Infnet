using MediatR;
using TechStore.Application.UseCases.Produto.Common;

namespace TechStore.Application.UseCases.Produto.CriarProduto
{
    public interface ICriarProduto : IRequestHandler<CriarProdutoInput, ProdutoOutput>
    {
    }
}
