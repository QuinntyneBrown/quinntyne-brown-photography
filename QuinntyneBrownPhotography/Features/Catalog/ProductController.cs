using MediatR;
using System.Threading.Tasks;
using System.Web.Http;

namespace QuinntyneBrownPhotography.Features.Catalog
{
    [Authorize]
    [RoutePrefix("api/product")]
    public class ProductController: ApiController
    {
        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("getbyslug")]
        public async Task<IHttpActionResult> GetBySlug(GetBySlugQuery.GetBySlugRequest request)
        {
            return Ok(await _mediator.SendAsync(request));
        }

        protected readonly IMediator _mediator;
    }
}
