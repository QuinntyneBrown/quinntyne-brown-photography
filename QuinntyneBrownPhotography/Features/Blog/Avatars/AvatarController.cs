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

        [Route("add")]
        [HttpPost]
        [ResponseType(typeof(AddOrUpdateAvatarCommand.AddOrUpdateAvatarResponse))]
        public async Task<IHttpActionResult> Add(AddOrUpdateAvatarCommand.AddOrUpdateAvatarRequest request)
            => Ok(await _mediator.SendAsync(request));

        [Route("update")]
        [HttpPut]
        [ResponseType(typeof(AddOrUpdateAvatarCommand.AddOrUpdateAvatarResponse))]
        public async Task<IHttpActionResult> Update(AddOrUpdateAvatarCommand.AddOrUpdateAvatarRequest request)
            => Ok(await _mediator.SendAsync(request));
        
        [Route("get")]
        [AllowAnonymous]
        [HttpGet]
        [ResponseType(typeof(GetAvatarsQuery.GetAvatarsResponse))]
        public async Task<IHttpActionResult> Get()
            => Ok(await _mediator.SendAsync(new GetAvatarsQuery.GetAvatarsRequest()));

        [Route("getById")]
        [HttpGet]
        [ResponseType(typeof(GetAvatarByIdQuery.GetAvatarByIdResponse))]
        public async Task<IHttpActionResult> GetById(GetAvatarByIdQuery.GetAvatarByIdRequest request)
            => Ok(await _mediator.SendAsync(request));

        [Route("remove")]
        [HttpDelete]
        [ResponseType(typeof(RemoveAvatarCommand.RemoveAvatarResponse))]
        public async Task<IHttpActionResult> Remove(RemoveAvatarCommand.RemoveAvatarRequest request)
            => Ok(await _mediator.SendAsync(request));

        protected readonly IMediator _mediator;

    }
}
