namespace TechStore.Application.UseCases.Produto.Common
{
    public class ProdutoOutput
    {
        public string NomeProduto { get; private set; }

        public string Descricao { get; private set; }

        public int QuantidadeEmEstoque { get; private set; }

        public decimal ValorUnitario { get; private set; }

        public DateTime CriadoEm { get; private set; }

        public ProdutoOutput(
            string nomeProduto,
            string descricao,
            int quantidadeEmEstoque,
            decimal valorUnitario,
            DateTime criadoEm
        )
        {
            NomeProduto = nomeProduto;
            Descricao = descricao;
            QuantidadeEmEstoque = quantidadeEmEstoque;
            ValorUnitario = valorUnitario;
            CriadoEm = criadoEm;
        }
    }
}
