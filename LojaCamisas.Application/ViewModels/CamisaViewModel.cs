using System.ComponentModel.DataAnnotations;

namespace LojaCamisas.Application.ViewModels
{
    public class CamisaViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Time")]
        [Required(ErrorMessage = "O nome do time é obrigatório")]
        public string Time { get; set; }

        [Display(Name = "Temporada (ex: 2023/2024)")]
        [Required(ErrorMessage = "A temporada é obrigatória")]
        public string Temporada { get; set; }

        [Display(Name = "Preço")]
        [Required(ErrorMessage = "O preço é obrigatório")]
        [DataType(DataType.Currency)]
        public decimal Preco { get; set; }

        [Display(Name = "Estoque")]
        public int QuantidadeEstoque { get; set; }
    }
}