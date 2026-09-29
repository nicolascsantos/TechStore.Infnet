using TechStore.Domain.Exceptions;
using TechStore.Domain.SeedWork;

namespace TechStore.Domain.Entities
{
    public class Produto : Entidade
    {
        public Produto(
            string nomeProduto,
            string descricao,
            int quantidadeEmEstoque,
            decimal valorUnitario
        )
        {
            NomeProduto = nomeProduto;
            Descricao = descricao;
            QuantidadeEmEstoque = quantidadeEmEstoque;
            ValorUnitario = valorUnitario;
            CriadoEm = DateTime.Now;
            Validar();
        }

        public string NomeProduto { get; private set; }

        public string Descricao { get; private set; }

        public int QuantidadeEmEstoque { get; private set; }

        public decimal ValorUnitario { get; private set; }

        public DateTime CriadoEm { get; private set; }

        public void Atualizar(string nomeProduto, string descricao, int quantidadeEmEstoque, decimal valorUnitario)
        {
            NomeProduto = nomeProduto;
            Descricao = descricao;
            QuantidadeEmEstoque = quantidadeEmEstoque;
            ValorUnitario = valorUnitario;
        }

        public void Validar()
        {
            if (string.IsNullOrWhiteSpace(NomeProduto))
                throw new ValidacaoDominioException("Nome não pode ser vazio ou nulo.");

            if (string.IsNullOrWhiteSpace(Descricao))
                throw new ValidacaoDominioException("Descricao não pode ser vazio ou nulo.");

            if (ValorUnitario < 0)
                throw new ValidacaoDominioException("ValorUnitario não pode ser negativo.");
        }
    }
}
