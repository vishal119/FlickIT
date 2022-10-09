
using Microsoft.Extensions.Caching.Memory;
using System;
using Util.Common.Interfaces;

namespace Util.Common
{
    public class InMemoryCache : IInMemoryCache
    {
        public InMemoryCache()
        {
            Cache = new MemoryCache(new MemoryCacheOptions
            {
                SizeLimit = _sizeLimit
            });
        }

        /// <summary>
        /// Try getting a value from the cache.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool TryGetValue<T>(string key, out T value)
        {
            value = default;

            if (Cache.TryGetValue(key, out T result))
            {
                value = result;
                return true;
            }
            return false;
        }

        /// <summary>
        ///  Adding a value to the cache. All entries
        /// have size = 1 and will expire after 1.5 minutes
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void SetValue<T>(string key, T value)
        {
            Cache.Set(key, value, new MemoryCacheEntryOptions()
              .SetSize(1)
              .SetAbsoluteExpiration(TimeSpan.FromSeconds(_absoluteExpiration))
            );
        }
        #region Private members
        private MemoryCache Cache { get; set; }
        private static readonly int _sizeLimit = 1024;
        private static readonly int _absoluteExpiration = 90;
        #endregion
    }
}
