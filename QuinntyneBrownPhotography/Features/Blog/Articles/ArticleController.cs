using MediatR;
using System.Threading.Tasks;
using System.Web.Http;

namespace QuinntyneBrownPhotography.Features.Blog.Articles
{
    [Authorize]
    [RoutePrefix("api/article")]
    public class ArticleController : ApiController
    {
        public ArticleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [AllowAnonymous]
        [Route("getbyslug")]
        public async Task<IHttpActionResult> GetBySlug(GetBySlugQuery.GetBySlugRequest request)
        {
            return Ok(await _mediator.SendAsync(request));
        }

        protected readonly IMediator _mediator;        
    }
}
