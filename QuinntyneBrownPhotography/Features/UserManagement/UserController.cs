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

        protected readonly IMediator _mediator;

    }
}
