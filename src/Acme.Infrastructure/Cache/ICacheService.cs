using System;
using System.Threading.Tasks;

namespace Acme.Infrastructure.Cache
{
    /// <summary>
    /// Service responsible to manager cache.
    /// </summary>
    public interface ICacheService
    {
        /// <summary>
        /// Gets a value with the given key.
        /// </summary>
        /// <param name="key">A string identifying the requested value.</param>
        /// <returns>
        /// The located value or null.
        /// </returns>
        Task<T> GetAsync<T>(string key);

        /// <summary>
        /// Gets or create a value with the given key.
        /// </summary>
        /// <param name="key">A string identifying the requested value.</param>
        /// <param name="value">Value to be cached.</param>
        /// <param name="cacheExpiration">How long a cache entry can be active.</param>
        /// <returns>
        /// The located value or null.
        /// </returns>
        Task SetAsync<T>(string key, T value, DateTimeOffset cacheExpiration) where T : class;

        /// <summary>
        /// Removes the value with the given key.
        /// </summary>
        /// <param name="key">A string identifying the requested value.</param>
        void Remove(string key);
    }
}
