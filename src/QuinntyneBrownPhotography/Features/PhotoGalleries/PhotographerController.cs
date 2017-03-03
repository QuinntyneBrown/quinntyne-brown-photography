using MediatR;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace QuinntyneBrownPhotography.Features.PhotoGalleries
{
    [Authorize]
    [RoutePrefix("api/photographer")]
    public class PhotographerController : ApiController
    {
        public PhotographerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route("add")]
        [HttpPost]
        [ResponseType(typeof(AddOrUpdatePhotographerCommand.AddOrUpdatePhotographerResponse))]
        public async Task<IHttpActionResult> Add(AddOrUpdatePhotographerCommand.AddOrUpdatePhotographerRequest request)
            => Ok(await _mediator.Send(request));

        [Route("update")]
        [HttpPut]
        [ResponseType(typeof(AddOrUpdatePhotographerCommand.AddOrUpdatePhotographerResponse))]
        public async Task<IHttpActionResult> Update(AddOrUpdatePhotographerCommand.AddOrUpdatePhotographerRequest request)
            => Ok(await _mediator.Send(request));
        
        [Route("get")]
        [AllowAnonymous]
        [HttpGet]
        [ResponseType(typeof(GetPhotographersQuery.GetPhotographersResponse))]
        public async Task<IHttpActionResult> Get()
            => Ok(await _mediator.Send(new GetPhotographersQuery.GetPhotographersRequest()));

        [Route("getById")]
        [HttpGet]
        [ResponseType(typeof(GetPhotographerByIdQuery.GetPhotographerByIdResponse))]
        public async Task<IHttpActionResult> GetById([FromUri]GetPhotographerByIdQuery.GetPhotographerByIdRequest request)
            => Ok(await _mediator.Send(request));

        [Route("remove")]
        [HttpDelete]
        [ResponseType(typeof(RemovePhotographerCommand.RemovePhotographerResponse))]
        public async Task<IHttpActionResult> Remove([FromUri]RemovePhotographerCommand.RemovePhotographerRequest request)
            => Ok(await _mediator.Send(request));

        protected readonly IMediator _mediator;

    }
}
