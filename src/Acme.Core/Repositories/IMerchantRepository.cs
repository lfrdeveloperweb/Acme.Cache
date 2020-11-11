using System.Threading.Tasks;
using Acme.Core.Models;

namespace Acme.Core.Repositories
{
    public interface IMerchantRepository
    {
        Task<Merchant> GetByIdAsync(string id);
    }
}
