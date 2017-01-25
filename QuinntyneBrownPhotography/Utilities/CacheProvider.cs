using QuinntyneBrownPhotography.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuinntyneBrownPhotography.Utilities
{
    public class CacheProvider : ICacheProvider
    {
        public ICache GetCache()
        {
            return MemoryCache.Current;
        }
    }
}
