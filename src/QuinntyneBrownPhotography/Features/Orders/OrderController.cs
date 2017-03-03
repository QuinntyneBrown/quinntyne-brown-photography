using MediatR;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace QuinntyneBrownPhotography.Features.Orders
{
    [Authorize]
    [RoutePrefix("api/order")]
    public class OrderController : ApiController
    {
        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        protected readonly IMediator _mediator;

    }
}
