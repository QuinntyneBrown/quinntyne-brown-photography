using MediatR;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace QuinntyneBrownPhotography.Features.Notifications
{
    [Authorize]
    [RoutePrefix("api/notification")]
    public class NotificationController : ApiController
    {
        public NotificationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route("send")]
        [HttpPost]
        [ResponseType(typeof(SendNotificationCommand.SendNotificationResponse))]
        public async Task<IHttpActionResult> Send(SendNotificationCommand.SendNotificationRequest request)
            => Ok(await _mediator.Send(request));

        protected readonly IMediator _mediator;

    }
}
