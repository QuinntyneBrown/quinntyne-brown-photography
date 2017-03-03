using MediatR;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace QuinntyneBrownPhotography.Features.Quizzes
{
    [Authorize]
    [RoutePrefix("api/poll")]
    public class PollController : ApiController
    {
        public PollController(IMediator mediator)
        {
            _mediator = mediator;
        }

        protected readonly IMediator _mediator;
    }
}
