using System;
using System.Runtime.Caching;

namespace ProxyCacheServer
{
    public class ProxyCacheGeneric<T>
    {
        private ObjectCache cache;

        public ProxyCacheGeneric()
        {
            cache = MemoryCache.Default;
        }

        public T Get(string CacheItemName)
        {
            if (cache.Contains(CacheItemName))
            {
                return (T)cache.Get(CacheItemName);
            }
            T obj = (T)Activator.CreateInstance(typeof(T), new object[] { CacheItemName });
            cache.Add(CacheItemName, obj, ObjectCache.InfiniteAbsoluteExpiration);
            return obj;
        }

        public T Get(string CacheItemName, double dt_seconds)
        {
            if (cache.Contains(CacheItemName))
            {
                return (T)cache.Get(CacheItemName);
            }
            T obj = (T)Activator.CreateInstance(typeof(T), new object[] { CacheItemName });
            var temp_data = new CacheItemPolicy
            {
                AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(dt_seconds), //Data remove after dt_seconds secondes

            };
            cache.Add(CacheItemName, obj, temp_data);
            return obj;
        }

        public T Get(string CacheItemName, DateTimeOffset dt)
        {
            if (cache.Contains(CacheItemName))
            {
                return (T)cache.Get(CacheItemName);
            }
            T obj = (T)Activator.CreateInstance(typeof(T), new object[] { CacheItemName });
            var temp_data = new CacheItemPolicy
            {
                AbsoluteExpiration = dt, //Data remove at dt

            };
            cache.Add(CacheItemName, obj, temp_data);
            return obj;
        }
    }
}
