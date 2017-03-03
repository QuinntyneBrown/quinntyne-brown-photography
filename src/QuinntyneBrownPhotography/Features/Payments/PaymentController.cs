using MediatR;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace QuinntyneBrownPhotography.Features.Payments
{
    [Authorize]
    [RoutePrefix("api/payment")]
    public class PaymentController : ApiController
    {
        public PaymentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route("process")]
        [HttpPost]
        [ResponseType(typeof(ProcessPaymentCommand.ProcessPaymentResponse))]
        public async Task<IHttpActionResult> Process(ProcessPaymentCommand.ProcessPaymentRequest request)
            => Ok(await _mediator.Send(request));

        protected readonly IMediator _mediator;

    }
}
