using MediatR;
using TechStore.Application.UseCases.Produto.Common;

namespace TechStore.Application.UseCases.Produto.AtualizarProduto
{
    public interface IAtualizarProduto : IRequestHandler<AtualizarProdutoInput, ProdutoOutput>
    {
    }
}
