using MediatR;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace QuinntyneBrownPhotography.Features.PhotoGalleries
{
    [Authorize]
    [RoutePrefix("api/photo")]
    public class PhotoController : ApiController
    {
        public PhotoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route("add")]
        [HttpPost]
        [ResponseType(typeof(AddOrUpdatePhotoCommand.AddOrUpdatePhotoResponse))]
        public async Task<IHttpActionResult> Add(AddOrUpdatePhotoCommand.AddOrUpdatePhotoRequest request)
            => Ok(await _mediator.Send(request));

        [Route("update")]
        [HttpPut]
        [ResponseType(typeof(AddOrUpdatePhotoCommand.AddOrUpdatePhotoResponse))]
        public async Task<IHttpActionResult> Update(AddOrUpdatePhotoCommand.AddOrUpdatePhotoRequest request)
            => Ok(await _mediator.Send(request));
        
        [Route("get")]
        [AllowAnonymous]
        [HttpGet]
        [ResponseType(typeof(GetPhotosQuery.GetPhotosResponse))]
        public async Task<IHttpActionResult> Get()
            => Ok(await _mediator.Send(new GetPhotosQuery.GetPhotosRequest()));

        [Route("getById")]
        [HttpGet]
        [ResponseType(typeof(GetPhotoByIdQuery.GetPhotoByIdResponse))]
        public async Task<IHttpActionResult> GetById([FromUri]GetPhotoByIdQuery.GetPhotoByIdRequest request)
            => Ok(await _mediator.Send(request));

        [Route("remove")]
        [HttpDelete]
        [ResponseType(typeof(RemovePhotoCommand.RemovePhotoResponse))]
        public async Task<IHttpActionResult> Remove([FromUri]RemovePhotoCommand.RemovePhotoRequest request)
            => Ok(await _mediator.Send(request));

        protected readonly IMediator _mediator;

    }
}
