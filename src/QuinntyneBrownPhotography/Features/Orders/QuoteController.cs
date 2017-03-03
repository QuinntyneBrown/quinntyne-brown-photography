using MediatR;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace QuinntyneBrownPhotography.Features.Orders
{
    [Authorize]
    [RoutePrefix("api/quote")]
    public class QuoteController : ApiController
    {
        public QuoteController(IMediator mediator)
        {
            _mediator = mediator;
        }

        protected readonly IMediator _mediator;

    }
}
