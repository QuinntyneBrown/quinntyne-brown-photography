using MediatR;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace QuinntyneBrownPhotography.Features.Polls
{
    [Authorize]
    [RoutePrefix("api/pollQuestion")]
    public class PollQuestionController : ApiController
    {
        public PollQuestionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        protected readonly IMediator _mediator;

    }
}
