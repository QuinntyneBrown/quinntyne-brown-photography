using MediatR;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace QuinntyneBrownPhotography.Features.RSS
{
    [Authorize]
    [RoutePrefix("api/rss")]
    public class RSSFeedController : ApiController
    {
        public RSSFeedController(IMediator mediator)
        {
            _mediator = mediator;
        }

        protected readonly IMediator _mediator;

    }
}
