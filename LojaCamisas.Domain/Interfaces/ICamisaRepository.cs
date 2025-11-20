using LojaCamisas.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LojaCamisas.Domain.Interfaces
{
    public interface ICamisaRepository : IRepository<Camisa>
    {
        Task<IEnumerable<Camisa>> BuscarAsync(string termo);
    }
}
