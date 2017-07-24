using Microsoft.Extensions.Caching.Memory;
using System;

namespace Common.Web.Data
{
    public class CachingEx : ICachingEx
    {
        private readonly IMemoryCache _memoryCache;

        public CachingEx(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public void Add<T>(string key, T value, int? expireMinutes = null)
        {
            _memoryCache.Set<T>(
                key,
                value,
                new MemoryCacheEntryOptions()
                {
                    Priority = CacheItemPriority.High,
                    SlidingExpiration = expireMinutes.HasValue ? new TimeSpan(0, expireMinutes.Value, 0) : new TimeSpan(24, 0, 0)
                }
            );
        }

        public void Remove(string key)
        {
            _memoryCache.Remove(key);
        }

        public bool Exists(string key)
        {
            return _memoryCache.Get(key) != null;
        }

        public T Get<T>(string key)
        {
            return _memoryCache.Get<T>(key);
        }
    }
}