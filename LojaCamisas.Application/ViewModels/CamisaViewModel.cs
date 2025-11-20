namespace LojaCamisas.Application.ViewModels
{
    public class CamisaViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public string Temporada { get; set; } = string.Empty;
        public decimal Preco { get; set; }
        public string MarcaNome { get; set; } = string.Empty;
    }
}
