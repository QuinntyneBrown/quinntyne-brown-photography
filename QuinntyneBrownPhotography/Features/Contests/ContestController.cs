using MediatR;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace QuinntyneBrownPhotography.Features.Contests
{
    [Authorize]
    [RoutePrefix("api/contest")]
    public class ContestController : ApiController
    {
        public ContestController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route("add")]
        [HttpPost]
        [ResponseType(typeof(AddOrUpdateContestCommand.AddOrUpdateContestResponse))]
        public async Task<IHttpActionResult> Add(AddOrUpdateContestCommand.AddOrUpdateContestRequest request)
            => Ok(await _mediator.Send(request));

        [Route("update")]
        [HttpPut]
        [ResponseType(typeof(AddOrUpdateContestCommand.AddOrUpdateContestResponse))]
        public async Task<IHttpActionResult> Update(AddOrUpdateContestCommand.AddOrUpdateContestRequest request)
            => Ok(await _mediator.Send(request));
        
        [Route("get")]
        [AllowAnonymous]
        [HttpGet]
        [ResponseType(typeof(GetContestsQuery.GetContestsResponse))]
        public async Task<IHttpActionResult> Get()
            => Ok(await _mediator.Send(new GetContestsQuery.GetContestsRequest()));

        [Route("getById")]
        [HttpGet]
        [ResponseType(typeof(GetContestByIdQuery.GetContestByIdResponse))]
        public async Task<IHttpActionResult> GetById(GetContestByIdQuery.GetContestByIdRequest request)
            => Ok(await _mediator.Send(request));

        [Route("remove")]
        [HttpDelete]
        [ResponseType(typeof(RemoveContestCommand.RemoveContestResponse))]
        public async Task<IHttpActionResult> Remove(RemoveContestCommand.RemoveContestRequest request)
            => Ok(await _mediator.Send(request));

        protected readonly IMediator _mediator;

    }
}
