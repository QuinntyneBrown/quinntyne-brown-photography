using QuinntyneBrownPhotography.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuinntyneBrownPhotography.Services
{
    public class CacheProvider : ICacheProvider
    {
        public ICache GetCache()
        {
            return MemoryCache.Current;
        }
    }
}
