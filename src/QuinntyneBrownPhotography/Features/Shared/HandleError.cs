using System.Web.Http.Filters;
using QuinntyneBrownPhotography.Features.Core;

namespace QuinntyneBrownPhotography.Features.Shared
{
    public class HandleErrorAttribute : ExceptionFilterAttribute
    {
        public HandleErrorAttribute(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger("Error");
        }

        public override void OnException(HttpActionExecutedContext context)
        {

        }

        protected readonly ILogger _logger;
    }
}


