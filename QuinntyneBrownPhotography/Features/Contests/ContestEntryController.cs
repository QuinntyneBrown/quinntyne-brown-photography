using MediatR;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace QuinntyneBrownPhotography.Features.Contests
{
    [Authorize]
    [RoutePrefix("api/contestEntry")]
    public class ContestEntryController : ApiController
    {
        public ContestEntryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route("add")]
        [HttpPost]
        [ResponseType(typeof(AddOrUpdateContestEntryCommand.AddOrUpdateContestEntryResponse))]
        public async Task<IHttpActionResult> Add(AddOrUpdateContestEntryCommand.AddOrUpdateContestEntryRequest request)
            => Ok(await _mediator.Send(request));

        [Route("update")]
        [HttpPut]
        [ResponseType(typeof(AddOrUpdateContestEntryCommand.AddOrUpdateContestEntryResponse))]
        public async Task<IHttpActionResult> Update(AddOrUpdateContestEntryCommand.AddOrUpdateContestEntryRequest request)
            => Ok(await _mediator.Send(request));
        
        [Route("get")]
        [AllowAnonymous]
        [HttpGet]
        [ResponseType(typeof(GetContestEntriesQuery.GetContestEntriesResponse))]
        public async Task<IHttpActionResult> Get()
            => Ok(await _mediator.Send(new GetContestEntriesQuery.GetContestEntrysRequest()));

        [Route("getById")]
        [HttpGet]
        [ResponseType(typeof(GetContestEntryByIdQuery.GetContestEntryByIdResponse))]
        public async Task<IHttpActionResult> GetById(GetContestEntryByIdQuery.GetContestEntryByIdRequest request)
            => Ok(await _mediator.Send(request));

        [Route("remove")]
        [HttpDelete]
        [ResponseType(typeof(RemoveContestEntryCommand.RemoveContestEntryResponse))]
        public async Task<IHttpActionResult> Remove(RemoveContestEntryCommand.RemoveContestEntryRequest request)
            => Ok(await _mediator.Send(request));

        protected readonly IMediator _mediator;

    }
}
