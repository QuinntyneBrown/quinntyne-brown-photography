using MediatR;
using System.Web.Http;

namespace QuinntyneBrownPhotography.Features.Quizzes
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
