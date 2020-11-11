namespace Acme.Core.Settings
{
    /// <summary>
    /// Cache settings.
    /// </summary>
    public class CacheSettings
    {
        /// <summary>
        /// Turns on or off the integration with cache.
        /// </summary>
        public bool IsEnabled { get; private set; }

        /// <summary>
        /// How long a cache entry can be active in minutes.
        /// </summary>
        public int CacheExpirationInMinutes { get; private set; }
    }
}