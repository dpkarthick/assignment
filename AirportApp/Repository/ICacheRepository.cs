using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportApp.Repository
{
    public interface ICacheRepository
    {
        T Get<T>(string cacheKey) where T : class;
        void Set<T>(string cacheKey, T CacheValue) where T : class;
    }
}
