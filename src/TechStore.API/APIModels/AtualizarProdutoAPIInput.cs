using TechStore.Application.UseCases.Produto.AtualizarProduto;

namespace TechStore.API.APIModels
{
    public record AtualizarProdutoAPIInput(
       Guid Id,
       string NomeProduto,
       string Descricao,
       int QuantidadeEmEstoque,
       decimal ValorUnitario
    )
    {
        public AtualizarProdutoInput ToAtualizarProdutoInput(Guid id, AtualizarProdutoAPIInput apiInput)
            => new AtualizarProdutoInput(
                id,
                apiInput.NomeProduto,
                apiInput.Descricao,
                apiInput.QuantidadeEmEstoque,
                apiInput.ValorUnitario
            );
    }
}
