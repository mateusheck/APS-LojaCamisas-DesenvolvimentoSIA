using System.ComponentModel.DataAnnotations;

namespace LojaCamisas.Application.Validation
{
    public class PrecoMinimoAttribute : ValidationAttribute
    {
        private readonly decimal _precoMinimo;

        public PrecoMinimoAttribute(double precoMinimo)
        {
            _precoMinimo = (decimal)precoMinimo;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is decimal preco)
            {
                if (preco < _precoMinimo)
                {
                    return new ValidationResult($"O preço deve ser superior a R$ {_precoMinimo:N2}.");
                }
            }

            return ValidationResult.Success;
        }
    }
}