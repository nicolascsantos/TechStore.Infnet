using TechStore.UnitTests.Common;
using Entidade = TechStore.Domain.Entities;

namespace TechStore.UnitTests.Dominio.Produto
{
    [CollectionDefinition(nameof(ProdutoFixture))]
    public class ProdutoFixtureCollection : ICollectionFixture<ProdutoFixture> { }

    public class ProdutoFixture : BaseFixture
    {
        public Random random = new Random();

        public Entidade.Produto GetProdutoValido()
            => new Entidade.Produto(
                GetNomeProdutoValido(),
                GetDescricaoValida(),
                GetNumeroRandomico(),
                GetValorUnitarioValido()
            );

        public string GetNomeProdutoValido()
            => Faker.Commerce.ProductName();

        public string GetDescricaoValida()
            => Faker.Commerce.ProductDescription();

        public int GetNumeroRandomico()
            => random.Next(1, 21);

        public decimal GetValorUnitarioValido()
            => 3_000;
    }
}
