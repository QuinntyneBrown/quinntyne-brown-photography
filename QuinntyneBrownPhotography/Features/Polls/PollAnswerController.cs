using MediatR;
using System.Web.Http;

namespace QuinntyneBrownPhotography.Features.Polls
{
    [Authorize]
    [RoutePrefix("api/pollanswer")]
    public class PollAnswerController : ApiController
    {
        public PollAnswerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        protected readonly IMediator _mediator;
    }
}
