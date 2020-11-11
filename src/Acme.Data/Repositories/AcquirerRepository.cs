using Acme.Core.Repositories;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;
using Acme.Core.Models;

namespace Acme.Data.Repositories
{
    public sealed class AcquirerRepository : IAcquirerRepository
    {
        private static readonly ConcurrentBag<Acquirer> Acquirers = new ConcurrentBag<Acquirer>
        {
            new Acquirer(1, "Rede"),
            new Acquirer(2, "GetNet"),
            new Acquirer(3, "Elavon")
        };

        public Task<Acquirer> GetByIdAsync(int id)
        {
            return Task.FromResult(Acquirers.FirstOrDefault(m => m.Id.Equals(id)));
        }
    }
}
