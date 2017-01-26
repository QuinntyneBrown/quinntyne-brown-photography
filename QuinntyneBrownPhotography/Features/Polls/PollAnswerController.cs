using MediatR;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace QuinntyneBrownPhotography.Features.Polls
{
    [Authorize]
    [RoutePrefix("api/pollAnswer")]
    public class PollAnswerController : ApiController
    {
        public PollAnswerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        protected readonly IMediator _mediator;

    }
}
