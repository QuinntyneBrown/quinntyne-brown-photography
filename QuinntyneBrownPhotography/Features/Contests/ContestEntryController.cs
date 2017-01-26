using MediatR;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace QuinntyneBrownPhotography.Features.Contests
{
    [Authorize]
    [RoutePrefix("api/contestEntry")]
    public class ContestEntryController : ApiController
    {
        public ContestEntryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        protected readonly IMediator _mediator;

    }
}
