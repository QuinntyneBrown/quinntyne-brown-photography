using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuinntyneBrownPhotography.Services
{
    public interface ICacheProvider
    {
        ICache GetCache();
    }
}
