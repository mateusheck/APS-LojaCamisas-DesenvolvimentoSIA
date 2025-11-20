using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace LojaCamisas.Application.ViewModels
{
    public class CamisaCreateEditViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "A descrição é obrigatória.")]
        public string Descricao { get; set; } = string.Empty;

        [Required(ErrorMessage = "A temporada é obrigatória.")]
        public string Temporada { get; set; } = string.Empty;

        [Required(ErrorMessage = "O preço é obrigatório.")]
        [Range(0.01, 99999)]
        public decimal Preco { get; set; }

        [Required(ErrorMessage = "Selecione uma marca.")]
        public int MarcaId { get; set; }

        public IEnumerable<SelectListItem> Marcas { get; set; } = new List<SelectListItem>();
    }
}
