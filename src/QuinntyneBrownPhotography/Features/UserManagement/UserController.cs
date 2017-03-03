using MediatR;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace QuinntyneBrownPhotography.Features.UserManagement
{
    [Authorize]
    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route("current")]
        [AllowAnonymous]
        [HttpGet]
        [ResponseType(typeof(GetCurrentUserQuery.GetCurrentUserResponse))]
        public async Task<IHttpActionResult> Current()
        {
            if (!User.Identity.IsAuthenticated)
                return Ok();
            return Ok(await _mediator.Send(new GetCurrentUserQuery.GetCurrentUserRequest(User.Identity.Name)));
        }
        
        protected readonly IMediator _mediator;

    }
}
