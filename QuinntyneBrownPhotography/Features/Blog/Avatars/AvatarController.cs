using MediatR;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace QuinntyneBrownPhotography.Features.Blog.Avatars
{
    [Authorize]
    [RoutePrefix("api/avatar")]
    public class AvatarController : ApiController
    {
        public AvatarController(IMediator mediator)
        {
            _mediator = mediator;
        }

        protected readonly IMediator _mediator;

    }
}
