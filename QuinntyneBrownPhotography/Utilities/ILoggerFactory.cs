using System.Collections.Generic;

namespace QuinntyneBrownPhotography.Utilities
{
    public interface ILoggerFactory
    {
        ILogger CreateLogger(string categoryName);

        List<ILoggerProvider> GetProviders();
    }
}
