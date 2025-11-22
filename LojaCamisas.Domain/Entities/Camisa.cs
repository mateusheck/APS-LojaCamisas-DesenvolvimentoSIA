namespace LojaCamisas.Domain.Entities
{
    public class Camisa
    {
        public Camisa() { }

        public int Id { get; set; }

        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public string Temporada { get; set; } = string.Empty;

        public int QuantidadeEstoque { get; set; }

        public decimal Preco { get; set; }

        public int MarcaId { get; set; }
        public Marca Marca { get; set; } = null!;
    }
}
