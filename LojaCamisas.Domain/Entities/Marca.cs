using LojaCamisas.Domain.Validation;
using System.Collections.Generic;

namespace LojaCamisas.Domain.Entities
{
    public class Marca : Entity
    {
        public string Nome { get; private set; }

        public ICollection<Camisa> Camisas { get; private set; } = new List<Camisa>();

        // Construtor público padrão para Mapster
        public Marca()
        {
            Nome = string.Empty;
        }

        public Marca(string nome)
        {
            Nome = nome;
        }

        public Marca(int id, string nome) : base(id)
        {
            Nome = nome;
        }
    }
}
