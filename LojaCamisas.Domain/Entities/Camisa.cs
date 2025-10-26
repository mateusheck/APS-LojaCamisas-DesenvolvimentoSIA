using System.ComponentModel.DataAnnotations;

namespace LojaCamisas.Domain.Entities
{
    public class Camisa
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do time é obrigatório")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O nome do time deve ter entre 3 e 100 caracteres")]
        public string Time { get; set; }

        [Required(ErrorMessage = "A temporada é obrigatória")]
        [StringLength(9, ErrorMessage = "Formato inválido (ex: 2023/2024)")]
        public string Temporada { get; set; }

        [Required(ErrorMessage = "O preço é obrigatório")]
        [Range(1, 10000, ErrorMessage = "O preço deve ser maior que zero")]
        [DataType(DataType.Currency)]
        public decimal Preco { get; set; }

        public int QuantidadeEstoque { get; set; }
    }
}
