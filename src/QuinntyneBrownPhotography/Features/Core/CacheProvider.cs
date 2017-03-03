using QuinntyneBrownPhotography.Features.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuinntyneBrownPhotography.Features.Core
{
    public class CacheProvider : ICacheProvider
    {
        public ICache GetCache()
        {
            return MemoryCache.Current;
        }
    }
}
