using MediatR;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace QuinntyneBrownPhotography.Features.PhotoGalleries
{
    [Authorize]
    [RoutePrefix("api/photoGallery")]
    public class PhotoGalleryController : ApiController
    {
        public PhotoGalleryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route("add")]
        [HttpPost]
        [ResponseType(typeof(AddOrUpdatePhotoGalleryCommand.AddOrUpdatePhotoGalleryResponse))]
        public async Task<IHttpActionResult> Add(AddOrUpdatePhotoGalleryCommand.AddOrUpdatePhotoGalleryRequest request)
            => Ok(await _mediator.Send(request));

        [Route("update")]
        [HttpPut]
        [ResponseType(typeof(AddOrUpdatePhotoGalleryCommand.AddOrUpdatePhotoGalleryResponse))]
        public async Task<IHttpActionResult> Update(AddOrUpdatePhotoGalleryCommand.AddOrUpdatePhotoGalleryRequest request)
            => Ok(await _mediator.Send(request));
        
        [Route("get")]
        [AllowAnonymous]
        [HttpGet]
        [ResponseType(typeof(GetPhotoGallerysQuery.GetPhotoGallerysResponse))]
        public async Task<IHttpActionResult> Get()
            => Ok(await _mediator.Send(new GetPhotoGallerysQuery.GetPhotoGallerysRequest()));

        [Route("getById")]
        [HttpGet]
        [ResponseType(typeof(GetPhotoGalleryByIdQuery.GetPhotoGalleryByIdResponse))]
        public async Task<IHttpActionResult> GetById([FromUri]GetPhotoGalleryByIdQuery.GetPhotoGalleryByIdRequest request)
            => Ok(await _mediator.Send(request));

        [Route("remove")]
        [HttpDelete]
        [ResponseType(typeof(RemovePhotoGalleryCommand.RemovePhotoGalleryResponse))]
        public async Task<IHttpActionResult> Remove([FromUri]RemovePhotoGalleryCommand.RemovePhotoGalleryRequest request)
            => Ok(await _mediator.Send(request));

        protected readonly IMediator _mediator;

    }
}
