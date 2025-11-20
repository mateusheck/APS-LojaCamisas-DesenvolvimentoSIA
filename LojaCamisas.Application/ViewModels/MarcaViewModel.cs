using System.ComponentModel.DataAnnotations;

namespace LojaCamisas.Application.ViewModels
{
    public class MarcaViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome da Marca é obrigatório")]
        [MinLength(3)]
        [MaxLength(100)]
        public string Nome { get; set; } = string.Empty;
    }
}