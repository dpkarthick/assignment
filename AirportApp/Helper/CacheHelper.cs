using AirportApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Web;

namespace AirportApp.Helper
{
    public class CacheHelper : ICacheRepository
    {
        /// <summary>
        /// Get Value from the Cache based on the Cachekey
        /// </summary>
        /// <returns></returns>
        public T Get<T>(string cacheKey) where T : class
        {
            T item = MemoryCache.Default.Get(cacheKey) as T;           
            return item;
        }

        /// <summary>
        /// Set the Cachevalue based on the cachekey
        /// </summary>
        /// <returns></returns>
        public void Set<T>(string cacheKey, T CacheValue) where T : class
        {
            MemoryCache.Default.Add(cacheKey, CacheValue, DateTime.Now.AddMinutes(5));          
        }
    }

}