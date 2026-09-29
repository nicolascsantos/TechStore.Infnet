using MediatR;
using TechStore.Application.UseCases.Produto.Common;

namespace TechStore.Application.UseCases.Produto.ObterProdutoPorId
{
    public record ObterProdutoPorIdInput(Guid Id) : IRequest<ProdutoOutput>;
    
}
