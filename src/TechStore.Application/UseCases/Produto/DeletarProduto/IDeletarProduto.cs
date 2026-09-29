using MediatR;

namespace TechStore.Application.UseCases.Produto.DeletarProduto
{
    public interface IDeletarProduto : IRequestHandler<DeletarProdutoInput, Unit>
    {
    }
}
