using TechStore.Application.UseCases.Produto.CriarProduto;

namespace TechStore.API.APIModels
{
    public record CriarProdutoAPIInput(
        string NomeProduto,
        string Descricao,
        int QuantidadeEmEstoque,
        decimal ValorUnitario
    )
    {
        public CriarProdutoInput ToProdutoInput() 
            => new CriarProdutoInput(NomeProduto, Descricao, QuantidadeEmEstoque, ValorUnitario);
    }
}
