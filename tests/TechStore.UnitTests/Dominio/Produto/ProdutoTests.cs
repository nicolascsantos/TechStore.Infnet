using FluentAssertions;
using Entidade = TechStore.Domain.Entities;

namespace TechStore.UnitTests.Dominio.Produto
{
    [Collection(nameof(ProdutoFixture))]
    public class ProdutoTests
    {
        private readonly ProdutoFixture _fixture;

        public ProdutoTests(ProdutoFixture fixture)
            => _fixture = fixture;

        [Fact(DisplayName = nameof(Instanciar))]
        public async Task Instanciar()
        {
            var produto = _fixture.GetProdutoValido();

            var dataAntes = DateTime.Now;

            var novoProduto = new Entidade.Produto(
                produto.NomeProduto,
                produto.Descricao,
                produto.QuantidadeEmEstoque,
                produto.ValorUnitario
            );

            var dataDepois = DateTime.Now;

            novoProduto.NomeProduto.Should().Be(produto.NomeProduto);
            novoProduto.Descricao.Should().Be(produto.Descricao);
            novoProduto.QuantidadeEmEstoque.Should().Be(produto.QuantidadeEmEstoque);
            novoProduto.ValorUnitario.Should().Be(produto.ValorUnitario);
            novoProduto.CriadoEm.Should().BeAfter(dataAntes);
            novoProduto.CriadoEm.Should().BeBefore(dataDepois);
        }
    }
}
