using MediatR;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace QuinntyneBrownPhotography.Features.Contacts
{
    [Authorize]
    [RoutePrefix("api/contact")]
    public class ContactController : ApiController
    {
        public ContactController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route("add")]
        [HttpPost]
        [ResponseType(typeof(AddContactMessageCommand.AddContactMessageResponse))]
        public async Task<IHttpActionResult> AddContactMessage(AddContactMessageCommand.AddContactMessageRequest request) {
            return Ok(await _mediator.SendAsync(request));
        }

        protected readonly IMediator _mediator;

    }
}
