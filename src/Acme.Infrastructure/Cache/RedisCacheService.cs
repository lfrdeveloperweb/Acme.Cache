using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace Acme.Infrastructure.Cache
{
    /// <summary>
    /// Redis distributed cache service
    /// </summary>
    public sealed class RedisCacheService : ICacheService
    {
        private readonly IDistributedCache _cache;

        public RedisCacheService(IDistributedCache cache)
        {
            this._cache = cache;
        }

        /// <summary>
        /// Gets a value with the given key.
        /// </summary>
        /// <param name="key">A string identifying the requested value.</param>
        /// <returns>
        /// The located value or null.
        /// </returns>
        public async Task<T> GetAsync<T>(string key)
        {
            string fromCache = await this._cache.GetStringAsync(key);

            return fromCache == null ? default : JsonConvert.DeserializeObject<T>(fromCache);
        }

        /// <summary>
        /// Gets or create a value with the given key.
        /// </summary>
        /// <param name="key">A string identifying the requested value.</param>
        /// <param name="value">Value to be cached.</param>
        /// <param name="cacheExpiration">How long a cache entry can be active.</param>
        /// <returns>
        /// The located value or null.
        /// </returns>
        public Task SetAsync<T>(string key, T value, DateTimeOffset cacheExpiration) where T : class
        {
            if (string.IsNullOrWhiteSpace(key)) throw new ArgumentNullException(nameof(key));
            if (value == null) throw new ArgumentNullException(nameof(value));

            string toStore = value as string ?? JsonConvert.SerializeObject(value);
            if (string.IsNullOrWhiteSpace(toStore))
            {
                return Task.CompletedTask;
            }

            return this._cache.SetStringAsync(key, toStore, new DistributedCacheEntryOptions { AbsoluteExpiration = cacheExpiration });
        }

        /// <summary>
        /// Removes the value with the given key.
        /// </summary>
        /// <param name="key">A string identifying the requested value.</param>
        public void Remove(string key)
        {
            this._cache.Remove(key);
        }
    }
}
