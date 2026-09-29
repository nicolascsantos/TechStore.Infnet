using MediatR;
using TechStore.Application.UseCases.Produto.Common;

namespace TechStore.Application.UseCases.Produto.ObterProdutoPorId
{
    public interface IObterProdutoPorId : IRequestHandler<ObterProdutoPorIdInput, ProdutoOutput>
    {
    }
}
