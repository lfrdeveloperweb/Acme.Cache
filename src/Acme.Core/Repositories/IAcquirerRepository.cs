using System.Threading.Tasks;
using Acme.Core.Models;

namespace Acme.Core.Repositories
{
    public interface IAcquirerRepository
    {
        Task<Acquirer> GetByIdAsync(int id);
    }
}