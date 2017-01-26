using MediatR;
using System.Web.Http;

namespace QuinntyneBrownPhotography.Features.Blog.Authors
{
    [Authorize]
    [RoutePrefix("api/author")]
    public class AuthorController : ApiController
    {
        public AuthorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        protected readonly IMediator _mediator;

    }
}
