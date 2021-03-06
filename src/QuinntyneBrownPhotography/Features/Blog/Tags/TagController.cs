using MediatR;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace QuinntyneBrownPhotography.Features.Blog.Tags
{
    [Authorize]
    [RoutePrefix("api/tag")]
    public class TagController : ApiController
    {
        public TagController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route("add")]
        [HttpPost]
        [ResponseType(typeof(AddOrUpdateTagCommand.AddOrUpdateTagResponse))]
        public async Task<IHttpActionResult> Add(AddOrUpdateTagCommand.AddOrUpdateTagRequest request)
            => Ok(await _mediator.Send(request));

        [Route("update")]
        [HttpPut]
        [ResponseType(typeof(AddOrUpdateTagCommand.AddOrUpdateTagResponse))]
        public async Task<IHttpActionResult> Update(AddOrUpdateTagCommand.AddOrUpdateTagRequest request)
            => Ok(await _mediator.Send(request));
        
        [Route("get")]
        [AllowAnonymous]
        [HttpGet]
        [ResponseType(typeof(GetTagsQuery.GetTagsResponse))]
        public async Task<IHttpActionResult> Get()
            => Ok(await _mediator.Send(new GetTagsQuery.GetTagsRequest()));

        [Route("getById")]
        [HttpGet]
        [ResponseType(typeof(GetTagByIdQuery.GetTagByIdResponse))]
        public async Task<IHttpActionResult> GetById(GetTagByIdQuery.GetTagByIdRequest request)
            => Ok(await _mediator.Send(request));

        [Route("remove")]
        [HttpDelete]
        [ResponseType(typeof(RemoveTagCommand.RemoveTagResponse))]
        public async Task<IHttpActionResult> Remove(RemoveTagCommand.RemoveTagRequest request)
            => Ok(await _mediator.Send(request));

        protected readonly IMediator _mediator;

    }
}
