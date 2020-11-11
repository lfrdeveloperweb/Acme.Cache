using System;
using System.Threading.Tasks;
using Acme.Core.Models;
using Acme.Core.Repositories;
using Acme.Core.Settings;
using Acme.Infrastructure.Cache;

namespace Acme.Data.Repositories.Cache
{
    public class MerchantCacheRepository : IMerchantRepository
    {
        private readonly IMerchantRepository _merchantRepository;
        private readonly ICacheService _cacheService;
        private readonly MerchantCacheSettings _merchantCacheSettings;

        public MerchantCacheRepository(IMerchantRepository merchantRepository, ICacheService cacheService, MerchantCacheSettings merchantCacheSettings)
        {
            this._merchantRepository = merchantRepository;
            this._cacheService = cacheService;
            this._merchantCacheSettings = merchantCacheSettings;
        }

        public async Task<Merchant> GetByIdAsync(string id)
        {
            if (this._merchantCacheSettings.IsEnabled == false)
            {
                return await this._merchantRepository.GetByIdAsync(id);
            }

            string cacheKey = $"merchant_{id}";
            
            var merchant = await this._cacheService.GetAsync<Merchant>(cacheKey);
            if (merchant != null)
            {
                return merchant;
            }

            merchant = await this._merchantRepository.GetByIdAsync(id);
            if (merchant == null) return null;

            var cacheExpiration = DateTimeOffset.UtcNow.AddMinutes(this._merchantCacheSettings.CacheExpirationInMinutes);
            await this._cacheService.SetAsync(cacheKey, merchant, cacheExpiration);

            return merchant;
        }
    }
}
