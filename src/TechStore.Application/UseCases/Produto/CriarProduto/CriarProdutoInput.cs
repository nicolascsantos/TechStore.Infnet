using MediatR;
using TechStore.Application.UseCases.Produto.Common;

namespace TechStore.Application.UseCases.Produto.CriarProduto
{
    public record CriarProdutoInput(
        string NomeProduto,
        string Descricao,
        int QuantidadeEmEstoque,
        decimal ValorUnitario
    ) : IRequest<ProdutoOutput>;
}
