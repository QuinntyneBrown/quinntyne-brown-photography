using MediatR;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace QuinntyneBrownPhotography.Features.Contests
{
    [Authorize]
    [RoutePrefix("api/contest")]
    public class ContestController : ApiController
    {
        public ContestController(IMediator mediator)
        {
            _mediator = mediator;
        }

        protected readonly IMediator _mediator;

    }
}
