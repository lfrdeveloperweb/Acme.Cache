using System;
using System.Threading.Tasks;
using Acme.Core.Models;
using Acme.Core.Repositories;
using Acme.Core.Settings;
using Acme.DataContracts.Acquirers;
using Acme.Infrastructure.Cache;

namespace Acme.Core.OperationHandlers.AcquirerOperationHandlers
{
    public class GetAcquirerOperationHandler : IGetAcquirerOperationHandler
    {
        private readonly IAcquirerRepository _acquirerRepository;
        private readonly ICacheService _cacheService;
        private readonly CacheSettings _cacheSettings;

        public GetAcquirerOperationHandler(IAcquirerRepository acquirerRepository, ICacheService cacheService, CacheSettings cacheSettings)
        {
            _acquirerRepository = acquirerRepository;
            _cacheService = cacheService;
            _cacheSettings = cacheSettings;
        }

        public async Task<GetAcquirerOperationOperationResponse> ProcessAsync(GetAcquirerOperationRequest request)
        {
            Acquirer acquirer = request.ForceRetrievingFromDatabase
                ? await this._acquirerRepository.GetByIdAsync(request.Id)
                : await this.GetAndStoreAcquirerInCacheAsync(request.Id);

            return new GetAcquirerOperationOperationResponse
            {
                Data = new AcquirerResponseData
                {
                    Id = acquirer.Id,
                    Name = acquirer.Name
                }
            };
        }

        /// <summary>
        /// Get and store acquirer in cache.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private async Task<Acquirer> GetAndStoreAcquirerInCacheAsync(int id)
        {
            string cacheKey = $"acquirer_{id}";

            var acquirer = await this._cacheService.GetAsync<Acquirer>(cacheKey);
            if (acquirer != null)
            {
                return acquirer;
            }

            acquirer = await this._acquirerRepository.GetByIdAsync(id);
            if (acquirer == null) return null;

            var cacheExpiration = DateTimeOffset.UtcNow.AddMinutes(this._cacheSettings.CacheExpirationInMinutes);
            await this._cacheService.SetAsync(cacheKey, acquirer, cacheExpiration);

            return acquirer;
        }
    }
}
