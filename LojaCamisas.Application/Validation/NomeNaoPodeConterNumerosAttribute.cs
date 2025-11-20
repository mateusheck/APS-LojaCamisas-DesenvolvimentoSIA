using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace LojaCamisas.Application.Validation
{
    public class NomeNaoPodeConterNumerosAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is string nome)
            {
                
                if (Regex.IsMatch(nome, @"\d"))
                {
                    return new ValidationResult("O nome não deve conter números.");
                }
            }
            return ValidationResult.Success;
        }
    }
}