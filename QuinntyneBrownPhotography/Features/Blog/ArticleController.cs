using MediatR;
using System.Web.Http;

namespace QuinntyneBrownPhotography.Features.Blog
{
    [Authorize]
    [RoutePrefix("api/article")]
    public class ArticleController : ApiController
    {
        public ArticleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        protected readonly IMediator _mediator;


    }
}
