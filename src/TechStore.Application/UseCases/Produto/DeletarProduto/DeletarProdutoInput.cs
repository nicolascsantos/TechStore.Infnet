using MediatR;

namespace TechStore.Application.UseCases.Produto.DeletarProduto
{
    public record DeletarProdutoInput(Guid Id) : IRequest<Unit>;
}
