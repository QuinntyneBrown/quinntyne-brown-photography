using MediatR;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace QuinntyneBrownPhotography.Features.Polls
{
    [Authorize]
    [RoutePrefix("api/pollRespondent")]
    public class PollRespondentController : ApiController
    {
        public PollRespondentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route("add")]
        [HttpPost]
        [ResponseType(typeof(AddOrUpdatePollRespondentCommand.AddOrUpdatePollRespondentResponse))]
        public async Task<IHttpActionResult> Add(AddOrUpdatePollRespondentCommand.AddOrUpdatePollRespondentRequest request)
            => Ok(await _mediator.Send(request));

        [Route("update")]
        [HttpPut]
        [ResponseType(typeof(AddOrUpdatePollRespondentCommand.AddOrUpdatePollRespondentResponse))]
        public async Task<IHttpActionResult> Update(AddOrUpdatePollRespondentCommand.AddOrUpdatePollRespondentRequest request)
            => Ok(await _mediator.Send(request));
        
        [Route("get")]
        [AllowAnonymous]
        [HttpGet]
        [ResponseType(typeof(GetPollRespondentsQuery.GetPollRespondentsResponse))]
        public async Task<IHttpActionResult> Get()
            => Ok(await _mediator.Send(new GetPollRespondentsQuery.GetPollRespondentsRequest()));

        [Route("getById")]
        [HttpGet]
        [ResponseType(typeof(GetPollRespondentByIdQuery.GetPollRespondentByIdResponse))]
        public async Task<IHttpActionResult> GetById([FromUri]GetPollRespondentByIdQuery.GetPollRespondentByIdRequest request)
            => Ok(await _mediator.Send(request));

        [Route("remove")]
        [HttpDelete]
        [ResponseType(typeof(RemovePollRespondentCommand.RemovePollRespondentResponse))]
        public async Task<IHttpActionResult> Remove([FromUri]RemovePollRespondentCommand.RemovePollRespondentRequest request)
            => Ok(await _mediator.Send(request));

        protected readonly IMediator _mediator;

    }
}
