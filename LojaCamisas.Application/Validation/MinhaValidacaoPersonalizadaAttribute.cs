using System.ComponentModel.DataAnnotations;

namespace LojaCamisas.Application.Validation
{
    public class MinhaValidacaoPersonalizadaAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
            {
                return ValidationResult.Success;
            }

            var strValue = value.ToString()?.Trim();

            if (strValue?.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Length == 3)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult(ErrorMessage ?? "A validação personalizada falhou.");
        }
    }
}