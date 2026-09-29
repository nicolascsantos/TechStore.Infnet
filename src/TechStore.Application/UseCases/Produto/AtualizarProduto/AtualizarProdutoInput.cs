using MediatR;
using TechStore.Application.UseCases.Produto.Common;

namespace TechStore.Application.UseCases.Produto.AtualizarProduto
{
    public record AtualizarProdutoInput(
        Guid Id,
        string NomeProduto,
        string Descricao,
        int QuantidadeEmEstoque,
        decimal ValorUnitario) : IRequest<ProdutoOutput>;
}
