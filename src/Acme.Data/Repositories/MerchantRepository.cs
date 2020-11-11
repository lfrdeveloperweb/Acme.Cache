using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;
using Acme.Core.Models;
using Acme.Core.Repositories;

namespace Acme.Data.Repositories
{
    public sealed class MerchantRepository : IMerchantRepository
    {
        private static readonly ConcurrentBag<Merchant> Merchants = new ConcurrentBag<Merchant>
        {
            new Merchant("33014556000196", "Lojas Americanas S.a."),
            new Merchant("3499243000104", "IBAZAR.COM ATIVIDADES DE INTERNET LTDA."),
            new Merchant("60500246000154", "Goodyear do Brasil Produtos de Borracha Ltda."),
        };

        public Task<Merchant> GetByIdAsync(string id)
        {
            return Task.FromResult(Merchants.FirstOrDefault(m => m.Id.Equals(id)));
        }
    }
}
